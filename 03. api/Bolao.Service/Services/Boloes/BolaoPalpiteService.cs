using AutoMapper;
using Bolao.Domain.Commands.Boloes;
using Bolao.Domain.Entities.Boloes;
using Bolao.Infrastructure.Interfaces.Repositories.Boloes;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Boloes;
using Core.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Boloes
{
    public class BolaoPalpiteService : IBolaoPalpiteService
    {
        private readonly IBolaoPalpiteRepository _bolaoPalpiteRepository;
        private readonly IValidator<CreateBolaoPalpiteCommand> _createBolaoPalpiteCommandValidator;
        private readonly IMapper _mapper;

        public BolaoPalpiteService(IBolaoPalpiteRepository bolaoPalpiteRepository, IValidator<CreateBolaoPalpiteCommand> createBolaoPalpiteCommandValidator, IMapper mapper)
        {
            _bolaoPalpiteRepository = bolaoPalpiteRepository;
            _createBolaoPalpiteCommandValidator = createBolaoPalpiteCommandValidator;
            _mapper = mapper;
        }

        public Task<IEnumerable<BolaoPalpite>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BolaoPalpite> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> SaveAsync(CreateBolaoPalpiteCommand command)
        {
            // validação
            var validation = await _createBolaoPalpiteCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível salvar o Palpite do Bolão.", new { Errors = mensagensDeErro });
            }

            // validação de duplicidade
            var entityExistente = await _bolaoPalpiteRepository.GetByUniqueKeyAsync(command.IdBolaoUsuario, command.IdCampeonatoPartida);
            if (entityExistente is null)  // se não existir, inserir
            {
                // criar a entidade
                var entity = _mapper.Map<BolaoPalpite>(command);

                // salvar
                var result = await _bolaoPalpiteRepository.CreateAsync(entity);
            }
            else  // se existir, atualizar
            {
                // alterar os atributos necessários
                entityExistente.PlacarTime1 = command.PlacarTime1;
                entityExistente.PlacarTime2 = command.PlacarTime2;

                // salvar
                var result = await _bolaoPalpiteRepository.UpdateAsync(entityExistente);
            }

            // retornar o resultado
            return new CommandResult(true, "Palpite do Bolão salvo com sucesso.", command);
        }
    }
}
