using Bolao.Domain.Commands.Propostas;
using Bolao.Domain.Enums.Propostas;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Propostas
{
    public class AlterarCondicaoPagtoCommandValidator : AbstractValidator<AlterarCondicaoPagtoCommand>
    {
        public AlterarCondicaoPagtoCommandValidator()
        {
            RuleFor(c => c.IdCondicaoPagto)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxProposta.IdCondicaoPagtoInvalido);

            When(c => c.IdCondicaoPagto == (int)CondicaoPagamentoEnum.CartaoCredito, () =>
            {
                RuleFor(c => c.IdOperadora)
                    .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxPropostaCartao.IdOperadoraInvalido);

                RuleFor(c => c.QuantidadeParcelas)
                    .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxPropostaCartao.QuantidadeParcelasInvalida);

                RuleFor(c => c.IdUsuario)
                    .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.IdUsuarioInvalido);

                RuleFor(c => c.IdLoja)
                    .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxProposta.IdLojaInvalido);
            });

            RuleFor(c => c.GuidProposta)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.GuidPropostaInvalido);

            //RuleFor(c => c.RealizarCalculosViaAPI)
            //    .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.RealizarCalculosViaAPIInvalido);
        }
    }
}
