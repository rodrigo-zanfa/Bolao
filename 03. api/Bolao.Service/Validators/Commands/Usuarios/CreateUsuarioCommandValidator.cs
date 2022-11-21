using Bolao.Domain.Commands.Usuarios;
using Bolao.Service.Constants;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Usuarios
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Usuario.NomeInvalido)
                .Length(1, 100).WithMessage(ValidatorMessageConstant.Usuario.NomeInvalido);

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Usuario.EmailInvalido)
                .Length(1, 100).WithMessage(ValidatorMessageConstant.Usuario.EmailInvalido)
                //.Must(c1 => c1.IsValidEmail()).WithMessage(ValidatorMessageConstant.Usuario.EmailInvalido);
                .EmailAddress(EmailValidationMode.Net4xRegex).WithMessage(ValidatorMessageConstant.Usuario.EmailInvalido);

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Usuario.SenhaInvalida)
                .Length(8, 15).WithMessage(ValidatorMessageConstant.Usuario.SenhaInvalida);

            RuleFor(c => c.SenhaConfirmacao)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Usuario.SenhaConfirmacaoInvalida)
                .Length(8, 15).WithMessage(ValidatorMessageConstant.Usuario.SenhaConfirmacaoInvalida)
                .Equal(c => c.Senha).WithMessage(ValidatorMessageConstant.Usuario.SenhasNaoConferem);

            RuleFor(c => c.UrlImagem)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Usuario.UrlImagemInvalida)
                .Length(1, 255).WithMessage(ValidatorMessageConstant.Usuario.UrlImagemInvalida)
                .Must(c1 => c1.IsValidUrl()).WithMessage(ValidatorMessageConstant.Usuario.UrlImagemInvalida);
        }
    }
}
