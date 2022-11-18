using Core.Commands;
using Bolao.Domain.Commands.Produtos;
using Bolao.Domain.Entities.Produtos;
using Bolao.Infrastructure.Interfaces.Repositories.Produtos;
using Bolao.Service.Interfaces.Services.Produtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Produtos
{
    public class EstruturaService : IEstruturaService
    {
        private readonly IEstruturaRepository _estruturaRepository;
        private readonly IValidator<CreateEstruturaCommand> _createEstruturaCommandValidator;
        private readonly IValidator<UpdateEstruturaCommand> _updateEstruturaCommandValidator;

        public EstruturaService(IEstruturaRepository estruturaRepository, IValidator<CreateEstruturaCommand> createEstruturaCommandValidator, IValidator<UpdateEstruturaCommand> updateEstruturaCommandValidator)
        {
            _estruturaRepository = estruturaRepository;
            _createEstruturaCommandValidator = createEstruturaCommandValidator;
            _updateEstruturaCommandValidator = updateEstruturaCommandValidator;
        }

        public async Task<IEnumerable<Estrutura>> GetAllAsync()
        {
            var result = await _estruturaRepository.GetAllAsync();

            return result;
        }

        public async Task<Estrutura> GetByIdAsync(int id)
        {
            var result = await _estruturaRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<Estrutura> GetByCodigoAsync(string codigo)
        {
            var result = await _estruturaRepository.GetByCodigoAsync(codigo);

            return result;
        }

        public /*async*/ Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();

            /*var createCommand = (CreateEstruturaCommand)command;

            // validação
            var validation = await _createEstruturaCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar a Estrutura.", validation.Errors);
            }

            // validação de duplicidade
            var entityExistente = await _estruturaRepository.GetByCodigoAsync(createCommand.Codigo);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Código da Estrutura já cadastrado.", entityExistente);
            }

            // criar a entidade
            var entity = new Estrutura(
                idEstrutura: 0,
                codigo: createCommand.Codigo,
                descricao: createCommand.Descricao,
                marca: createCommand.Marca,
                modelo: createCommand.Modelo,
                unidade: createCommand.Unidade,
                quantidade: createCommand.Quantidade,
                idTelhado: createCommand.IdTelhado,
                usuarioInclusaoOuAlteracao: createCommand.UsuarioInclusao
            );

            // salvar
            var result = await _estruturaRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Estrutura criada com sucesso.", entity);*/
        }

        public /*async*/ Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();

            /*var updateCommand = (UpdateEstruturaCommand)command;

            // validação
            var validation = await _updateEstruturaCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                return new CommandResult(false, "Não foi possível atualizar a Estrutura.", validation.Errors);
            }

            // validação de chave existente
            var entityExistente = await _estruturaRepository.GetByIdAsync(updateCommand.IdEstrutura);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Estrutura não encontrada para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = new Estrutura(
                idEstrutura: updateCommand.IdEstrutura,
                codigo: updateCommand.Codigo,
                descricao: updateCommand.Descricao,
                marca: updateCommand.Marca,
                modelo: updateCommand.Modelo,
                unidade: updateCommand.Unidade,
                quantidade: updateCommand.Quantidade,
                idTelhado: updateCommand.IdTelhado,
                usuarioInclusaoOuAlteracao: updateCommand.UsuarioAlteracao
            );

            // salvar
            var result = await _estruturaRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Estrutura atualizada com sucesso.", entity);*/
        }
    }
}
