using AutoMapper;
using Core.Commands;
using Bolao.Domain.Commands.TabelasConfiguracoes;
using Bolao.Domain.Entities.TabelasConfiguracoes;
using Bolao.Infrastructure.Interfaces.Repositories.TabelasConfiguracoes;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.TabelasConfiguracoes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.TabelasConfiguracoes
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        private readonly IConfiguracaoRepository _configuracaoRepository;
        private readonly IValidator<UpdateConfiguracaoCommand> _updateConfiguracaoCommandValidator;
        private readonly IMapper _mapper;

        public ConfiguracaoService(IConfiguracaoRepository configuracaoRepository, IValidator<UpdateConfiguracaoCommand> updateConfiguracaoCommandValidator, IMapper mapper)
        {
            _configuracaoRepository = configuracaoRepository;
            _updateConfiguracaoCommandValidator = updateConfiguracaoCommandValidator;
            _mapper = mapper;
        }

        public Task<IEnumerable<Configuracao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Configuracao> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Configuracao> GetAsync()
        {
            var result = await _configuracaoRepository.GetAsync() ?? new Configuracao();

            return result;
        }

        public Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> UpdateAsync(ICommand command)
        {
            var updateCommand = (UpdateConfiguracaoCommand)command;

            // validação
            var validation = await _updateConfiguracaoCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível atualizar a Configuração.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _configuracaoRepository.GetByIdAsync(updateCommand.IdConfiguracao);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Configuração não encontrada para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<Configuracao>(updateCommand);

            // salvar
            var result = await _configuracaoRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Configuração atualizada com sucesso.", entity);
        }
    }
}
