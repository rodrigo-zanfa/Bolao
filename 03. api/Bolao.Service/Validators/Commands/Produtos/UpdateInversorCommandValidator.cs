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
    public class UpdateInversorCommandValidator : AbstractValidator<UpdateInversorCommand>
    {
        public UpdateInversorCommandValidator()
        {
            RuleFor(c => c.IdInversor)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Inversor.IdInvalido);

            RuleFor(c => c.PotenciaSaida)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Inversor.PotenciaSaidaInvalida);
        }
    }
}
