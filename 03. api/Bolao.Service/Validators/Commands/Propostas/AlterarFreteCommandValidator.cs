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
    public class AlterarFreteCommandValidator : AbstractValidator<AlterarFreteCommand>
    {
        public AlterarFreteCommandValidator()
        {
            RuleFor(c => c.TipoFrete)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.TipoFreteInvalido);

            RuleFor(c => c.GuidProposta)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.GuidPropostaInvalido);

            //RuleFor(c => c.RealizarCalculosViaAPI)
            //    .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.RealizarCalculosViaAPIInvalido);
        }
    }
}
