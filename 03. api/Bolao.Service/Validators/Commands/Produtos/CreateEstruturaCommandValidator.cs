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
    public class CreateEstruturaCommandValidator : AbstractValidator<CreateEstruturaCommand>
    {
        public CreateEstruturaCommandValidator()
        {
            RuleFor(c => c.IdTelhado.Count)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Estrutura.IdTelhadoInvalido);
        }
    }
}
