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
    public class ClasseParceiroService : IClasseParceiroService
    {
        private readonly IClasseParceiroRepository _classeParceiroRepository;
        private readonly IValidator<UpdateClasseParceiroCommand> _updateClasseParceiroCommandValidator;
        private readonly IMapper _mapper;

        public ClasseParceiroService(IClasseParceiroRepository classeParceiroRepository, IValidator<UpdateClasseParceiroCommand> updateClasseParceiroCommandValidator, IMapper mapper)
        {
            _classeParceiroRepository = classeParceiroRepository;
            _updateClasseParceiroCommandValidator = updateClasseParceiroCommandValidator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClasseParceiro>> GetAllAsync()
        {
            var result = await _classeParceiroRepository.GetAllAsync();

            return result;
        }

        public Task<ClasseParceiro> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> UpdateAsync(ICommand command)
        {
            var updateCommand = (UpdateClasseParceiroCommand)command;

            // validação
            var validation = await _updateClasseParceiroCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível atualizar a Classe do Parceiro.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _classeParceiroRepository.GetByIdAsync(updateCommand.IdClasseParceiro);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Classe do Parceiro não encontrada para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<ClasseParceiro>(updateCommand);

            // salvar
            var result = await _classeParceiroRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Classe do Parceiro atualizada com sucesso.", entity);
        }
    }
}
