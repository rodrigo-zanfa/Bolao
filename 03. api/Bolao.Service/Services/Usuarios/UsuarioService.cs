using AutoMapper;
using Bolao.Domain.Commands.Usuarios;
using Bolao.Domain.Entities.Usuarios;
using Bolao.Infrastructure.Interfaces.Repositories.Usuarios;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Usuarios;
using Core.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<CreateUsuarioCommand> _createUsuarioCommandValidator;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IValidator<CreateUsuarioCommand> createUsuarioCommandValidator, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _createUsuarioCommandValidator = createUsuarioCommandValidator;
            _mapper = mapper;
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetByNomeAsync(string nome)
        {
            var result = await _usuarioRepository.GetByNomeAsync(nome);

            return result;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            var result = await _usuarioRepository.GetByEmailAsync(email);

            return result;
        }

        public async Task<Usuario> GetByNomeEmailAsync(string nome, string email)
        {
            var result = await _usuarioRepository.GetByNomeEmailAsync(nome, email);

            return result;
        }

        public async Task<ICommandResult> CreateAsync(ICommand command)
        {
            var createCommand = (CreateUsuarioCommand)command;

            // validação
            var validation = await _createUsuarioCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível criar o Usuário.", new { Errors = mensagensDeErro });
            }

            // validação de duplicidade
            var entityExistente = await _usuarioRepository.GetByEmailAsync(createCommand.Email);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "E-mail do Usuário já cadastrado.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<Usuario>(createCommand);

            // criptografar a senha
            entity.Senha = PasswordHashHelper.Hash(entity.Senha);

            // salvar
            var result = await _usuarioRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Usuário criado com sucesso.", entity);
        }

        public Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
