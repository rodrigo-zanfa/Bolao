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
    public class CreateBolaoPalpiteCommandValidator : AbstractValidator<CreateBolaoPalpiteCommand>
    {
        public CreateBolaoPalpiteCommandValidator()
        {
            RuleFor(c => c.IdBolaoUsuario)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.BolaoPalpite.IdBolaoUsuarioInvalido);

            RuleFor(c => c.IdCampeonatoPartida)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.BolaoPalpite.IdCampeonatoPartidaInvalido);

            RuleFor(c => c.PlacarTime1)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.BolaoPalpite.PlacarTime1Invalido);

            RuleFor(c => c.PlacarTime2)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.BolaoPalpite.PlacarTime2Invalido);
        }
    }
}
