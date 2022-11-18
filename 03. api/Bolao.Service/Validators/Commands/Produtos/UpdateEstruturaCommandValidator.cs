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
    public class UpdateEstruturaCommandValidator : AbstractValidator<UpdateEstruturaCommand>
    {
        public UpdateEstruturaCommandValidator()
        {
            RuleFor(c => c.IdEstrutura)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Estrutura.IdInvalido);

            RuleFor(c => c.IdTelhado.Count)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Estrutura.IdTelhadoInvalido);
        }
    }
}
