using Bolao.Domain.Commands.Campeonatos;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Campeonatos
{
    public class CreateCampeonatoPartidaCommandValidator : AbstractValidator<CreateCampeonatoPartidaCommand>
    {
        public CreateCampeonatoPartidaCommandValidator()
        {
            //RuleFor(c => c.DtPartida)
            //    .GreaterThanOrEqualTo(DateTime.Now).WithMessage(ValidatorMessageConstant.CampeonatoPartida.DtPartidaInvalida);

            RuleFor(c => c.IdEstadio)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdEstadioInvalido);

            RuleFor(c => c.IdCampeonatoTime1)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdCampeonatoTime1Invalido);

            RuleFor(c => c.IdCampeonatoTime2)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdCampeonatoTime2Invalido);

            RuleFor(c => c.Peso)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.PesoInvalido);
        }
    }
}
