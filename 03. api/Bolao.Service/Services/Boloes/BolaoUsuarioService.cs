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
    public class BolaoUsuarioService : IBolaoUsuarioService
    {
        private readonly IBolaoUsuarioRepository _bolaoUsuarioRepository;
        private readonly IValidator<CreateBolaoUsuarioCommand> _createBolaoUsuarioCommandValidator;
        private readonly IMapper _mapper;

        public BolaoUsuarioService(IBolaoUsuarioRepository bolaoUsuarioRepository, IValidator<CreateBolaoUsuarioCommand> createBolaoUsuarioCommandValidator, IMapper mapper)
        {
            _bolaoUsuarioRepository = bolaoUsuarioRepository;
            _createBolaoUsuarioCommandValidator = createBolaoUsuarioCommandValidator;
            _mapper = mapper;
        }

        public Task<IEnumerable<BolaoUsuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BolaoUsuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BolaoUsuario> GetByUniqueKeyAsync(int idBolao, int idUsuario)
        {
            var result = await _bolaoUsuarioRepository.GetByUniqueKeyAsync(idBolao, idUsuario);

            return result;
        }

        public async Task<ICommandResult> CreateAsync(ICommand command)
        {
            var createCommand = (CreateBolaoUsuarioCommand)command;

            // validação
            var validation = await _createBolaoUsuarioCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível criar o Usuário no Bolão.", new { Errors = mensagensDeErro });
            }

            // validação de duplicidade
            var entityExistente = await _bolaoUsuarioRepository.GetByUniqueKeyAsync(createCommand.IdBolao, createCommand.IdUsuario);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Usuário no Bolão já cadastrado.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<BolaoUsuario>(createCommand);

            // salvar
            var result = await _bolaoUsuarioRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Usuário no Bolão criado com sucesso.", entity);
        }

        public Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
