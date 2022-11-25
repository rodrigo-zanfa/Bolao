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
            RuleFor(c => c.DtPartida)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage(ValidatorMessageConstant.CampeonatoPartida.DtPartidaInvalida);

            RuleFor(c => c.IdEstadio)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdEstadioInvalido);

            RuleFor(c => c.IdCampeonatoTime1)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdCampeonatoTime1Invalido);

            RuleFor(c => c.IdCampeonatoTime2)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdCampeonatoTime2Invalido);

            //When(c => (c.PlacarTime1 is not null || c.PlacarTime2 is not null), () =>
            //{
            //    RuleFor(c => c.PlacarTime1)
            //        .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.PlacarTime1Invalido);

            //    RuleFor(c => c.PlacarTime2)
            //        .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.PlacarTime2Invalido);
            //});
        }
    }
}
