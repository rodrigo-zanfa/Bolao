using AutoMapper;
using Bolao.Domain.Commands.Campeonatos;
using Bolao.Domain.Entities.Campeonatos;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Importacoes;
using Bolao.Service.Interfaces.Services.Importacoes.APIs;
using Core.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Importacoes
{
    public class ImportacaoService : IImportacaoService
    {
        private readonly Copa2022Service _copa2022Service;
        private readonly ITimeRepository _timeRepository;
        private readonly ICampeonatoTimeRepository _campeonatoTimeRepository;
        private readonly ICampeonatoPartidaRepository _campeonatoPartidaRepository;
        private readonly IValidator<CreateTimeCommand> _createTimeCommandValidator;
        private readonly IValidator<CreateCampeonatoPartidaCommand> _createCampeonatoPartidaCommandValidator;
        private readonly IMapper _mapper;

        public ImportacaoService(ITimeRepository timeRepository, ICampeonatoTimeRepository campeonatoTimeRepository, ICampeonatoPartidaRepository campeonatoPartidaRepository, IValidator<CreateTimeCommand> createTimeCommandValidator, IValidator<CreateCampeonatoPartidaCommand> createCampeonatoPartidaCommandValidator, IMapper mapper)
        {
            _copa2022Service = new Copa2022Service();
            _timeRepository = timeRepository;
            _campeonatoTimeRepository = campeonatoTimeRepository;
            _campeonatoPartidaRepository = campeonatoPartidaRepository;
            _createTimeCommandValidator = createTimeCommandValidator;
            _createCampeonatoPartidaCommandValidator = createCampeonatoPartidaCommandValidator;
            _mapper = mapper;
        }

        public async Task<ICommandResult> ImportarCopa2022Async()
        {
            await ImportarTimesAsync();

            await ImportarPartidasAsync();

            // retornar o resultado
            return new CommandResult(true, "Importação da Copa 2022 concluída com sucesso.", /*result*/ null);
        }

        private async Task<bool> ImportarTimesAsync()
        {
            var lista = await _copa2022Service.GetTimesAsync();

            foreach (var item in lista)
            {
                var idTimeAux = (int)item.id;
                var nome = (string)item.name_en;
                var sigla = (string)item.fifa_code;
                var urlImagem = (string)item.flag;

                var createCommand = new CreateTimeCommand()
                {
                    IdTimeAux = idTimeAux,
                    Nome = nome,
                    Sigla = sigla,
                    UrlImagem = urlImagem
                };

                // validação
                var validation = await _createTimeCommandValidator.ValidateAsync(createCommand);
                if (!validation.IsValid)
                {
                    //var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                    //return new CommandResult(false, "Não foi possível criar o Time.", new { Errors = mensagensDeErro });
                    return false;
                }

                // validação de duplicidade
                var entityExistente = await _timeRepository.GetByIdAuxAsync(createCommand.IdTimeAux);
                if (entityExistente is not null)
                {
                    //return new CommandResult(false, "Código do Time já cadastrado.", entityExistente);
                    return false;
                }

                // criar a entidade
                var entity = _mapper.Map<Time>(createCommand);

                // salvar
                var result = await _timeRepository.CreateAsync(entity);
            }

            return true;
        }

        private async Task<bool> ImportarPartidasAsync()
        {
            var lista = await _copa2022Service.GetPartidasAsync();

            foreach (var item in lista)
            {
                var dtPartida = (DateTime)item.local_date;
                var idEstadio = (int)item.stadium_id;

                var idTimeAux1 = (int)item.home_team_id;
                var time1 = await _timeRepository.GetByIdAuxAsync(idTimeAux1);
                var campeonatoTime1 = await _campeonatoTimeRepository.GetByUniqueKeyAsync(1, time1.IdTime);

                var idTimeAux2 = (int)item.away_team_id;
                var time2 = await _timeRepository.GetByIdAuxAsync(idTimeAux2);
                var campeonatoTime2 = await _campeonatoTimeRepository.GetByUniqueKeyAsync(1, time2.IdTime);

                var createCommand = new CreateCampeonatoPartidaCommand()
                {
                    DtPartida = dtPartida,
                    IdEstadio = idEstadio,
                    IdCampeonatoTime1 = campeonatoTime1.IdCampeonatoTime,
                    IdCampeonatoTime2 = campeonatoTime2.IdCampeonatoTime
                };

                // validação
                var validation = await _createCampeonatoPartidaCommandValidator.ValidateAsync(createCommand);
                if (!validation.IsValid)
                {
                    //var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                    //return new CommandResult(false, "Não foi possível criar a Partida do Campeonato.", new { Errors = mensagensDeErro });
                    return false;
                }

                // validação de duplicidade
                var entityExistente = await _campeonatoPartidaRepository.GetByUniqueKeyAsync(createCommand.DtPartida, createCommand.IdCampeonatoTime1, createCommand.IdCampeonatoTime2);
                if (entityExistente is not null)
                {
                    //return new CommandResult(false, "Partida do Campeonato já cadastrada.", entityExistente);
                    return false;
                }

                // criar a entidade
                var entity = _mapper.Map<CampeonatoPartida>(createCommand);

                // salvar
                var result = await _campeonatoPartidaRepository.CreateAsync(entity);
            }

            return true;
        }
    }
}
