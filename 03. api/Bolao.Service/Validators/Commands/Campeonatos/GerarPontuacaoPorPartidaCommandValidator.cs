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
    public class GerarPontuacaoPorPartidaCommandValidator : AbstractValidator<GerarPontuacaoPorPartidaCommand>
    {
        public GerarPontuacaoPorPartidaCommandValidator()
        {
            RuleFor(c => c.IdCampeonatoPartida)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.CampeonatoPartida.IdCampeonatoPartidaInvalido);
        }
    }
}
