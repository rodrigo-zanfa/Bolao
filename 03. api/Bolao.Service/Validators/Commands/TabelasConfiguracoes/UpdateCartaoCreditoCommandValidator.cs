using Bolao.Domain.Commands.TabelasConfiguracoes;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.TabelasConfiguracoes
{
    public class UpdateCartaoCreditoCommandValidator : AbstractValidator<UpdateCartaoCreditoCommand>
    {
        public UpdateCartaoCreditoCommandValidator()
        {
            RuleFor(c => c.IdCartaoCredito)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CartaoCredito.IdCartaoCreditoInvalido);

            RuleFor(c => c.Bandeira)
                .NotEmpty().WithMessage(ValidatorMessageConstant.CartaoCredito.BandeiraInvalida)
                .Length(1, 20).WithMessage(ValidatorMessageConstant.CartaoCredito.BandeiraInvalida);

            RuleFor(c => c.Taxa01X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa01XInvalida);

            RuleFor(c => c.Taxa02X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa02XInvalida);

            RuleFor(c => c.Taxa03X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa03XInvalida);

            RuleFor(c => c.Taxa04X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa04XInvalida);

            RuleFor(c => c.Taxa05X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa05XInvalida);

            RuleFor(c => c.Taxa06X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa06XInvalida);

            RuleFor(c => c.Taxa07X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa07XInvalida);

            RuleFor(c => c.Taxa08X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa08XInvalida);

            RuleFor(c => c.Taxa09X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa09XInvalida);

            RuleFor(c => c.Taxa10X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa10XInvalida);

            RuleFor(c => c.Taxa11X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa11XInvalida);

            RuleFor(c => c.Taxa12X)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CartaoCredito.Taxa12XInvalida);
        }
    }
}
