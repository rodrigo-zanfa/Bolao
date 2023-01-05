using AutoMapper;
using Core.Commands;
using Bolao.Domain.Commands.ClassesParceiros;
using Bolao.Domain.Entities.ClassesParceiros;
using Bolao.Infrastructure.Interfaces.Repositories.ClassesParceiros;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.ClassesParceiros;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.ClassesParceiros
{
    public class ClasseParceiroDistribuidorService : IClasseParceiroDistribuidorService
    {
        private readonly IClasseParceiroDistribuidorRepository _classeParceiroDistribuidorRepository;
        private readonly IValidator<CreateClasseParceiroDistribuidorCommand> _createClasseParceiroDistribuidorCommandValidator;
        private readonly IValidator<UpdateClasseParceiroDistribuidorCommand> _updateClasseParceiroDistribuidorCommandValidator;
        private readonly IMapper _mapper;

        public ClasseParceiroDistribuidorService(IClasseParceiroDistribuidorRepository classeParceiroDistribuidorRepository, IValidator<CreateClasseParceiroDistribuidorCommand> createClasseParceiroDistribuidorCommandValidator, IValidator<UpdateClasseParceiroDistribuidorCommand> updateClasseParceiroDistribuidorCommandValidator, IMapper mapper)
        {
            _classeParceiroDistribuidorRepository = classeParceiroDistribuidorRepository;
            _createClasseParceiroDistribuidorCommandValidator = createClasseParceiroDistribuidorCommandValidator;
            _updateClasseParceiroDistribuidorCommandValidator = updateClasseParceiroDistribuidorCommandValidator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClasseParceiroDistribuidor>> GetAllAsync()
        {
            var result = await _classeParceiroDistribuidorRepository.GetAllAsync();

            return result;
        }

        public async Task<ClasseParceiroDistribuidor> GetByIdAsync(int id)
        {
            var result = await _classeParceiroDistribuidorRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<ICommandResult> CreateAsync(ICommand command)
        {
            var createCommand = (CreateClasseParceiroDistribuidorCommand)command;

            // validação
            var validation = await _createClasseParceiroDistribuidorCommandValidator.ValidateAsync(createCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível criar a Classe do Parceiro Distribuidor.", new { Errors = mensagensDeErro });
            }

            // validação de duplicidade
            var entityExistente = await _classeParceiroDistribuidorRepository.GetByLojaAsync(createCommand.IdLoja);
            if (entityExistente is not null)
            {
                return new CommandResult(false, "Classe do Parceiro Distribuidor já cadastrada.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<ClasseParceiroDistribuidor>(createCommand);

            // salvar
            var result = await _classeParceiroDistribuidorRepository.CreateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Classe do Parceiro Distribuidor criada com sucesso.", entity);
        }

        public async Task<ICommandResult> UpdateAsync(ICommand command)
        {
            var updateCommand = (UpdateClasseParceiroDistribuidorCommand)command;

            // validação
            var validation = await _updateClasseParceiroDistribuidorCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível atualizar a Classe do Parceiro Distribuidor.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _classeParceiroDistribuidorRepository.GetByIdAsync(updateCommand.IdClasseParceiroDistribuidor);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Classe do Parceiro Distribuidor não encontrada para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<ClasseParceiroDistribuidor>(updateCommand);

            // salvar
            var result = await _classeParceiroDistribuidorRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Classe do Parceiro Distribuidor atualizada com sucesso.", entity);
        }

        public async Task<ICommandResult> UpdateClasseAsync(int idClasseParceiroDistribuidor, int idClasseParceiro)
        {
            // validação de chave existente
            var entityExistente = await _classeParceiroDistribuidorRepository.GetByIdAsync(idClasseParceiroDistribuidor);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Classe do Parceiro Distribuidor não encontrada para alteração de Classe.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.IdClasseParceiro = idClasseParceiro;

            // salvar
            var result = await _classeParceiroDistribuidorRepository.UpdateAsync(entityExistente);

            // retornar o resultado
            return new CommandResult(true, "Classe do Parceiro Distribuidor atualizada com sucesso.", entityExistente);
        }
    }
}
