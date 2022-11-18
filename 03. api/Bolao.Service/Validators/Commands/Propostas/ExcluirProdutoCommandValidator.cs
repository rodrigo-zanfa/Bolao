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
    public class ExcluirProdutoCommandValidator : AbstractValidator<ExcluirProdutoCommand>
    {
        public ExcluirProdutoCommandValidator()
        {
            RuleFor(c => c.IdAux)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxPropostaGrid.IdAuxInvalido);

            RuleFor(c => c.GuidProposta)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.GuidPropostaInvalido);

            //RuleFor(c => c.RealizarCalculosViaAPI)
            //    .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.RealizarCalculosViaAPIInvalido);
        }
    }
}
