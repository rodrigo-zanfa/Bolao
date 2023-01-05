using AutoMapper;
using Core.Commands;
using Bolao.Domain.Commands.Produtos;
using Bolao.Domain.Entities.Produtos;
using Bolao.Infrastructure.Interfaces.Repositories.Produtos;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Produtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IValidator<CreateProdutoCommand> _createProdutoCommandValidator;
        private readonly IValidator<UpdateProdutoCommand> _updateProdutoCommandValidator;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IValidator<CreateProdutoCommand> createProdutoCommandValidator, IValidator<UpdateProdutoCommand> updateProdutoCommandValidator, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _createProdutoCommandValidator = createProdutoCommandValidator;
            _updateProdutoCommandValidator = updateProdutoCommandValidator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            var result = await _produtoRepository.GetAllAsync();

            return result;
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            var result = await _produtoRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<Produto> GetByCodigoAsync(string codigo)
        {
            var result = await _produtoRepository.GetByCodigoAsync(codigo);

            return result;
        }

        public async Task<ICommandResult> CreateAsync(ICommand command)
        {
            var createCommand = (CreateProdutoCommand)command;

            // validação
            var validation = await _createProdutoCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível criar o Produto.", new { Errors = mensagensDeErro });
            }

            // validação de duplicidade
            var entityExistente = await _produtoRepository.GetByCodigoAsync(createCommand.Codigo);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Código do Produto já cadastrado.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<Produto>(createCommand);

            // salvar
            var result = await _produtoRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Produto criado com sucesso.", entity);
        }

        public async Task<ICommandResult> UpdateAsync(ICommand command)
        {
            var updateCommand = (UpdateProdutoCommand)command;

            // validação
            var validation = await _updateProdutoCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível atualizar o Produto.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _produtoRepository.GetByIdAsync(updateCommand.IdProduto);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Produto não encontrado para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<Produto>(updateCommand);

            // salvar
            var result = await _produtoRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Produto atualizado com sucesso.", entity);
        }

        public async Task<ICommandResult> UpdateStatusAsync(int id, string ativo, string usuarioAlteracao)
        {
            // validação de chave existente
            var entityExistente = await _produtoRepository.GetByIdAsync(id);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Produto não encontrado para alteração de Status.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.Ativo = ativo;
            entityExistente.UsuarioAlteracao = usuarioAlteracao;

            // salvar
            var result = await _produtoRepository.UpdateAsync(entityExistente);

            // retornar o resultado
            return new CommandResult(true, "Status do Produto atualizado com sucesso.", entityExistente);
        }
    }
}
