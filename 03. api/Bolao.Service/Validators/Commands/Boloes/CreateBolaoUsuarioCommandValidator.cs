using Bolao.Domain.Commands.Boloes;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Boloes
{
    public class CreateBolaoUsuarioCommandValidator : AbstractValidator<CreateBolaoUsuarioCommand>
    {
        public CreateBolaoUsuarioCommandValidator()
        {
            RuleFor(c => c.IdBolao)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.BolaoUsuario.IdBolaoInvalido);

            RuleFor(c => c.IdUsuario)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.BolaoUsuario.IdUsuarioInvalido);
        }
    }
}
