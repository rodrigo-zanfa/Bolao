using Bolao.Domain.Commands.Propostas;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Propostas
{
    public class AlterarSeguroCommandValidator : AbstractValidator<AlterarSeguroCommand>
    {
        public AlterarSeguroCommandValidator()
        {
            RuleFor(c => c.HabilitaSeguro)
                .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.HabilitaSeguroInvalido);

            RuleFor(c => c.GuidProposta)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.GuidPropostaInvalido);

            //RuleFor(c => c.RealizarCalculosViaAPI)
            //    .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.RealizarCalculosViaAPIInvalido);
        }
    }
}
