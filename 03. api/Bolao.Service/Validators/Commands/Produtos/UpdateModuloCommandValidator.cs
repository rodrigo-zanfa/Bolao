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
    public class UpdateModuloCommandValidator : AbstractValidator<UpdateModuloCommand>
    {
        public UpdateModuloCommandValidator()
        {
            RuleFor(c => c.IdModulo)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Modulo.IdInvalido);

            RuleFor(c => c.DescricaoGrid)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Modulo.DescricaoGridInvalida);

            RuleFor(c => c.Potencia)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Modulo.PotenciaInvalida);
        }
    }
}
