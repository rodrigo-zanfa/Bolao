using Bolao.Domain.Commands.ClassesParceiros;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.ClassesParceiros
{
    public class UpdateClasseParceiroCommandValidator : AbstractValidator<UpdateClasseParceiroCommand>
    {
        public UpdateClasseParceiroCommandValidator()
        {
            RuleFor(c => c.IdClasseParceiro)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.ClasseParceiro.IdClasseParceiroInvalido);

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage(ValidatorMessageConstant.ClasseParceiro.DescricaoInvalida)
                .Length(1, 5).WithMessage(ValidatorMessageConstant.ClasseParceiro.DescricaoInvalida);

            // TODO: regra comentada provisoriamente devido às margens aplicadas serem negativas, devido à questões comerciais
            //RuleFor(c => c.PorcentagemElsys)
            //    .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.ClasseParceiro.PorcentagemElsysInvalida);
        }
    }
}
