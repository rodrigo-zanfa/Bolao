using AutoMapper;
using Bolao.Domain.Commands.Campeonatos;
using Bolao.Domain.Entities.Campeonatos;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Campeonatos;
using Bolao.Service.Interfaces.Services.Pontuacoes;
using Core.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Campeonatos
{
    public class CampeonatoPartidaService : ICampeonatoPartidaService
    {
        private readonly ICampeonatoPartidaRepository _campeonatoPartidaRepository;
        private readonly IPontuacaoService _pontuacaoService;
        private readonly IValidator<CreateCampeonatoPartidaCommand> _createCampeonatoPartidaCommandValidator;
        private readonly IValidator<UpdatePlacarCampeonatoPartidaCommand> _updatePlacarCampeonatoPartidaCommandValidator;
        private readonly IMapper _mapper;

        public CampeonatoPartidaService(ICampeonatoPartidaRepository campeonatoPartidaRepository, IPontuacaoService pontuacaoService, IValidator<CreateCampeonatoPartidaCommand> createCampeonatoPartidaCommandValidator, IValidator<UpdatePlacarCampeonatoPartidaCommand> updatePlacarCampeonatoPartidaCommandValidator, IMapper mapper)
        {
            _campeonatoPartidaRepository = campeonatoPartidaRepository;
            _pontuacaoService = pontuacaoService;
            _createCampeonatoPartidaCommandValidator = createCampeonatoPartidaCommandValidator;
            _updatePlacarCampeonatoPartidaCommandValidator = updatePlacarCampeonatoPartidaCommandValidator;
            _mapper = mapper;
        }

        public Task<IEnumerable<CampeonatoPartida>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CampeonatoPartida> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> CreateAsync(ICommand command)
        {
            var createCommand = (CreateCampeonatoPartidaCommand)command;

            // validação
            var validation = await _createCampeonatoPartidaCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível criar a Partida do Campeonato.", new { Errors = mensagensDeErro });
            }

            // validação de duplicidade
            var entityExistente = await _campeonatoPartidaRepository.GetByUniqueKeyAsync(createCommand.DtPartida, createCommand.IdCampeonatoTime1, createCommand.IdCampeonatoTime2);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Partida do Campeonato já cadastrada.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<CampeonatoPartida>(createCommand);

            // salvar
            var result = await _campeonatoPartidaRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Partida do Campeonato criada com sucesso.", entity);
        }

        public Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> UpdatePlacarAsync(UpdatePlacarCampeonatoPartidaCommand command)
        {
            // validação
            var validation = await _updatePlacarCampeonatoPartidaCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível atualizar o Placar da Partida do Campeonato.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _campeonatoPartidaRepository.GetByIdAsync(command.IdCampeonatoPartida);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Partida do Campeonato não encontrada para atualização.", entityExistente);
            }

            // alterar os atributos
            entityExistente.PlacarTime1 = command.PlacarTime1;
            entityExistente.PlacarTime2 = command.PlacarTime2;

            // salvar
            var result = await _campeonatoPartidaRepository.UpdateAsync(entityExistente);

            // atualizar as pontuações de todos os bolões
            await _pontuacaoService.GerarPontuacaoPorPartidaAsync(command.IdCampeonatoPartida);

            // retornar o resultado
            return new CommandResult(true, "Placar da Partida do Campeonato atualizado com sucesso.", command);
        }
    }
}
