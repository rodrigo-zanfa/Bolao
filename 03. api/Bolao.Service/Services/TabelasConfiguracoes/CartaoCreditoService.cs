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
using System.Web.Mvc;

namespace Bolao.Service.Services.TabelasConfiguracoes
{
    public class CartaoCreditoService : ICartaoCreditoService
    {
        private readonly ICartaoCreditoRepository _cartaoCreditoRepository;
        private readonly IValidator<UpdateCartaoCreditoCommand> _updateCartaoCreditoCommandValidator;
        private readonly IMapper _mapper;

        public CartaoCreditoService(ICartaoCreditoRepository cartaoCreditoRepository, IValidator<UpdateCartaoCreditoCommand> updateCartaoCreditoCommandValidator, IMapper mapper)
        {
            _cartaoCreditoRepository = cartaoCreditoRepository;
            _updateCartaoCreditoCommandValidator = updateCartaoCreditoCommandValidator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartaoCredito>> GetAllAsync()
        {
            var result = await _cartaoCreditoRepository.GetAllAsync();

            return result;
        }

        public async Task<CartaoCredito> GetByIdAsync(int id)
        {
            var result = await _cartaoCreditoRepository.GetByIdAsync(id) ?? new CartaoCredito();

            return result;
        }

        public Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandResult> UpdateAsync(ICommand command)
        {
            var updateCommand = (UpdateCartaoCreditoCommand)command;

            // validação
            var validation = await _updateCartaoCreditoCommandValidator.ValidateAsync(updateCommand);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível atualizar o Cartão de Crédito.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _cartaoCreditoRepository.GetByIdAsync(updateCommand.IdCartaoCredito);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Cartão de Crédito não encontrado para atualização.", entityExistente);
            }

            // criar a entidade
            var entity = _mapper.Map<CartaoCredito>(updateCommand);

            // salvar
            var result = await _cartaoCreditoRepository.UpdateAsync(entity);

            // retornar o resultado
            return new CommandResult(true, "Cartão de Crédito atualizado com sucesso.", entity);
        }
    }
}
