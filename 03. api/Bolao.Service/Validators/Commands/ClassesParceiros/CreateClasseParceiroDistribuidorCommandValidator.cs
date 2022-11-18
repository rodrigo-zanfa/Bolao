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
    public class CreateClasseParceiroDistribuidorCommandValidator : AbstractValidator<CreateClasseParceiroDistribuidorCommand>
    {
        public CreateClasseParceiroDistribuidorCommandValidator()
        {
            RuleFor(c => c.IdLoja)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.ClasseParceiroDistribuidor.IdLojaInvalido);

            RuleFor(c => c.IdClasseParceiro)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.ClasseParceiroDistribuidor.IdClasseParceiroInvalido);

            RuleFor(c => c.PorcentagemParceiro)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.ClasseParceiroDistribuidor.PorcentagemParceiroInvalida);
        }
    }
}
