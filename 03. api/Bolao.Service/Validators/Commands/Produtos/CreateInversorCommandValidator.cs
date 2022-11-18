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
    public class CreateInversorCommandValidator : AbstractValidator<CreateInversorCommand>
    {
        public CreateInversorCommandValidator()
        {
            RuleFor(c => c.PotenciaSaida)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Inversor.PotenciaSaidaInvalida);
        }
    }
}
