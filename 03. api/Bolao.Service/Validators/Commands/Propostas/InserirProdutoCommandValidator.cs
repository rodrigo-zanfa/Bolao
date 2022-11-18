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
    public class InserirProdutoCommandValidator : AbstractValidator<InserirProdutoCommand>
    {
        public InserirProdutoCommandValidator()
        {
            RuleFor(c => c.CodProduto)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxPropostaGrid.CodProdutoInvalido)
                .Length(14, 19).WithMessage(ValidatorMessageConstant.AuxPropostaGrid.CodProdutoInvalido)
                .Must(c1 => c1.IsValidCodigo()).WithMessage(ValidatorMessageConstant.AuxPropostaGrid.CodProdutoInvalido);

            RuleFor(c => c.QtdDesejada)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxPropostaGrid.QtdDesejadaInvalida);

            RuleFor(c => c.GuidProposta)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.GuidPropostaInvalido);

            //RuleFor(c => c.RealizarCalculosViaAPI)
            //    .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.RealizarCalculosViaAPIInvalido);
        }
    }
}
