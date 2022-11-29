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
    public class UpdatePlacarCampeonatoPartidaCommandValidator : AbstractValidator<UpdatePlacarCampeonatoPartidaCommand>
    {
        public UpdatePlacarCampeonatoPartidaCommandValidator()
        {
            RuleFor(c => c.IdCampeonatoPartida)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdCampeonatoPartidaInvalido);

            When(c => (c.PlacarTime1 is not null || c.PlacarTime2 is not null), () =>
            {
                RuleFor(c => c.PlacarTime1)
                    .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.PlacarTime1Invalido);

                RuleFor(c => c.PlacarTime2)
                    .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.PlacarTime2Invalido);
            });
        }
    }
}
