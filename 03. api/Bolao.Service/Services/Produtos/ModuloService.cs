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
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IValidator<CreateModuloCommand> _createModuloCommandValidator;
        private readonly IValidator<UpdateModuloCommand> _updateModuloCommandValidator;

        public ModuloService(IModuloRepository moduloRepository, IValidator<CreateModuloCommand> createModuloCommandValidator, IValidator<UpdateModuloCommand> updateModuloCommandValidator)
        {
            _moduloRepository = moduloRepository;
            _createModuloCommandValidator = createModuloCommandValidator;
            _updateModuloCommandValidator = updateModuloCommandValidator;
        }

        public async Task<IEnumerable<Modulo>> GetAllAsync()
        {
            var result = await _moduloRepository.GetAllAsync();

            return result;
        }

        public async Task<Modulo> GetByIdAsync(int id)
        {
            var result = await _moduloRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<Modulo> GetByCodigoAsync(string codigo)
        {
            var result = await _moduloRepository.GetByCodigoAsync(codigo);

            return result;
        }

        public /*async*/ Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();

            /*var createCommand = (CreateModuloCommand)command;

            // validação
            var validation = await _createModuloCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar o Módulo.", validation.Errors);
            }

            // validação de duplicidade
            var entityExistente = await _moduloRepository.GetByCodigoAsync(createCommand.Codigo);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Código do Módulo já cadastrado.", entityExistente);
            }

            // criar a entidade
            var entity = new Modulo(
                idModulo: 0,
                codigo: createCommand.Codigo,
                descricao: createCommand.Descricao,
                descricaoGrid: createCommand.DescricaoGrid,
                marca: createCommand.Marca,
                modelo: createCommand.Modelo,
                unidade: createCommand.Unidade,
                potencia: createCommand.Potencia,
                correnteMaxima: createCommand.CorrenteMaxima,
                tensaoMaxima: createCommand.TensaoMaxima,
                correnteCurtoCircuito: createCommand.CorrenteCurtoCircuito,
                tensaoCircuitoAberto: createCommand.TensaoCircuitoAberto,
                coeficiente: createCommand.Coeficiente,
                comprimento: createCommand.Comprimento,
                largura: createCommand.Largura,
                espessura: createCommand.Espessura,
                ativo: createCommand.Ativo,
                usuarioInclusaoOuAlteracao: createCommand.UsuarioInclusao
            );

            // salvar
            var result = await _moduloRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Módulo criado com sucesso.", entity);*/
        }

        public /*async*/ Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();

            /*var updateCommand = (UpdateModuloCommand)command;

            // validação
            var validation = await _updateModuloCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                return new CommandResult(false, "Não foi possível atualizar o Módulo.", validation.Errors);
            }

            // validação de chave existente
            var entityExistente = await _moduloRepository.GetByIdAsync(updateCommand.IdModulo);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Módulo não encontrado para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = new Modulo(
                idModulo: updateCommand.IdModulo,
                codigo: updateCommand.Codigo,
                descricao: updateCommand.Descricao,
                descricaoGrid: updateCommand.DescricaoGrid,
                marca: updateCommand.Marca,
                modelo: updateCommand.Modelo,
                unidade: updateCommand.Unidade,
                potencia: updateCommand.Potencia,
                correnteMaxima: updateCommand.CorrenteMaxima,
                tensaoMaxima: updateCommand.TensaoMaxima,
                correnteCurtoCircuito: updateCommand.CorrenteCurtoCircuito,
                tensaoCircuitoAberto: updateCommand.TensaoCircuitoAberto,
                coeficiente: updateCommand.Coeficiente,
                comprimento: updateCommand.Comprimento,
                largura: updateCommand.Largura,
                espessura: updateCommand.Espessura,
                ativo: updateCommand.Ativo,
                usuarioInclusaoOuAlteracao: updateCommand.UsuarioAlteracao
            );

            // salvar
            var result = await _moduloRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Módulo atualizado com sucesso.", entity);*/
        }
    }
}
