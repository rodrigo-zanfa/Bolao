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
    public class InversorService : IInversorService
    {
        private readonly IInversorRepository _inversorRepository;
        private readonly IValidator<CreateInversorCommand> _createInversorCommandValidator;
        private readonly IValidator<UpdateInversorCommand> _updateInversorCommandValidator;

        public InversorService(IInversorRepository inversorRepository, IValidator<CreateInversorCommand> createInversorCommandValidator, IValidator<UpdateInversorCommand> updateInversorCommandValidator)
        {
            _inversorRepository = inversorRepository;
            _createInversorCommandValidator = createInversorCommandValidator;
            _updateInversorCommandValidator = updateInversorCommandValidator;
        }

        public async Task<IEnumerable<Inversor>> GetAllAsync()
        {
            var result = await _inversorRepository.GetAllAsync();

            return result;
        }

        public async Task<Inversor> GetByIdAsync(int id)
        {
            var result = await _inversorRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<Inversor> GetByCodigoAsync(string codigo)
        {
            var result = await _inversorRepository.GetByCodigoAsync(codigo);

            return result;
        }

        public /*async*/ Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();

            /*var createCommand = (CreateInversorCommand)command;

            // validação
            var validation = await _createInversorCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                return new CommandResult(false, "Não foi possível criar o Inversor.", validation.Errors);
            }

            // validação de duplicidade
            var entityExistente = await _inversorRepository.GetByCodigoAsync(createCommand.Codigo);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Código do Inversor já cadastrado.", entityExistente);
            }

            // criar a entidade
            var entity = new Inversor(
                idInversor: 0,
                codigo: createCommand.Codigo,
                //descricao: createCommand.Descricao,
                idMarca: createCommand.IdMarca,
                modelo: createCommand.Modelo,
                unidade: createCommand.Unidade,
                idFase: createCommand.IdFase,
                tensaoCA: createCommand.TensaoCA,
                tensaoCC: createCommand.TensaoCC,
                potenciaSaida: createCommand.PotenciaSaida,
                potenciaMinima: createCommand.PotenciaMinima,
                potenciaMaxima: createCommand.PotenciaMaxima,
                potenciaRecomendada: createCommand.PotenciaRecomendada,
                tensaoMinimaEntrada: createCommand.TensaoMinimaEntrada,
                tensaoMinimaLigar: createCommand.TensaoMinimaLigar,
                quantidadeMPPT: createCommand.QuantidadeMPPT,
                quantidadeStrings: createCommand.QuantidadeStrings,
                correnteCA: createCommand.CorrenteCA,
                tipo: createCommand.Tipo,
                idFaseConjugada: createCommand.IdFaseConjugada,
                idFaseConjugada2: createCommand.IdFaseConjugada2,
                idFaseConjugada3Trifasica380V: createCommand.IdFaseConjugada3Trifasica380V,
                moduloMinimo: createCommand.ModuloMinimo,
                moduloMaximo: createCommand.ModuloMaximo,
                correnteCurtoCircuito: createCommand.CorrenteCurtoCircuito,
                ativo: createCommand.Ativo,
                usuarioInclusaoOuAlteracao: createCommand.UsuarioInclusao
            );

            // salvar
            var result = await _inversorRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Inversor criado com sucesso.", entity);*/
        }

        public /*async*/ Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();

            /*var updateCommand = (UpdateInversorCommand)command;

            // validação
            var validation = await _updateInversorCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                return new CommandResult(false, "Não foi possível atualizar o Inversor.", validation.Errors);
            }

            // validação de chave existente
            var entityExistente = await _inversorRepository.GetByIdAsync(updateCommand.IdInversor);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Inversor não encontrado para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = new Inversor(
                idInversor: updateCommand.IdInversor,
                codigo: updateCommand.Codigo,
                //descricao: updateCommand.Descricao,
                idMarca: updateCommand.IdMarca,
                modelo: updateCommand.Modelo,
                unidade: updateCommand.Unidade,
                idFase: updateCommand.IdFase,
                tensaoCA: updateCommand.TensaoCA,
                tensaoCC: updateCommand.TensaoCC,
                potenciaSaida: updateCommand.PotenciaSaida,
                potenciaMinima: updateCommand.PotenciaMinima,
                potenciaMaxima: updateCommand.PotenciaMaxima,
                potenciaRecomendada: updateCommand.PotenciaRecomendada,
                tensaoMinimaEntrada: updateCommand.TensaoMinimaEntrada,
                tensaoMinimaLigar: updateCommand.TensaoMinimaLigar,
                quantidadeMPPT: updateCommand.QuantidadeMPPT,
                quantidadeStrings: updateCommand.QuantidadeStrings,
                correnteCA: updateCommand.CorrenteCA,
                tipo: updateCommand.Tipo,
                idFaseConjugada: updateCommand.IdFaseConjugada,
                idFaseConjugada2: updateCommand.IdFaseConjugada2,
                idFaseConjugada3Trifasica380V: updateCommand.IdFaseConjugada3Trifasica380V,
                moduloMinimo: updateCommand.ModuloMinimo,
                moduloMaximo: updateCommand.ModuloMaximo,
                correnteCurtoCircuito: updateCommand.CorrenteCurtoCircuito,
                ativo: updateCommand.Ativo,
                usuarioInclusaoOuAlteracao: updateCommand.UsuarioAlteracao
            );

            // salvar
            var result = await _inversorRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Inversor atualizado com sucesso.", entity);*/
        }
    }
}
