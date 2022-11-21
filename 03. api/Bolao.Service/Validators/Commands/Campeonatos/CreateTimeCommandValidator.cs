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
    public class CreateTimeCommandValidator : AbstractValidator<CreateTimeCommand>
    {
        public CreateTimeCommandValidator()
        {
            RuleFor(c => c.IdTimeAux)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Time.IdTimeAuxInvalido);

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Time.NomeInvalido)
                .Length(1, 100).WithMessage(ValidatorMessageConstant.Time.NomeInvalido);

            RuleFor(c => c.Sigla)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Time.SiglaInvalida)
                .Length(1, 3).WithMessage(ValidatorMessageConstant.Time.SiglaInvalida);

            RuleFor(c => c.UrlImagem)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Time.UrlImagemInvalida)
                .Length(1, 255).WithMessage(ValidatorMessageConstant.Time.UrlImagemInvalida)
                .Must(c1 => c1.IsValidUrl()).WithMessage(ValidatorMessageConstant.Time.UrlImagemInvalida);
        }
    }
}
