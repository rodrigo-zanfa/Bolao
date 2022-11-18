using Bolao.Domain.Commands.Produtos;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Produtos
{
    public class UpdateCaboCommandValidator : AbstractValidator<UpdateCaboCommand>
    {
        public UpdateCaboCommandValidator()
        {
            RuleFor(c => c.IdCabo)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Cabo.IdInvalido);

            RuleFor(c => c.IdTipoInversor)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Cabo.IdTipoInversorInvalido);
        }
    }
}
