using Bolao.Domain.Commands.Propostas;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Propostas
{
    public class AlterarServicoCommandValidator : AbstractValidator<AlterarServicoCommand>
    {
        public AlterarServicoCommandValidator()
        {
            RuleFor(c => c.ValorProjeto)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.AuxPropostaServico.ValorProjetoInvalido);

            RuleFor(c => c.ValorInstalacao)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.AuxPropostaServico.ValorInstalacaoInvalido);

            RuleFor(c => c.IdUsuario)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.IdUsuarioInvalido);

            RuleFor(c => c.IdLoja)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.AuxProposta.IdLojaInvalido);

            RuleFor(c => c.GuidProposta)
                .NotEmpty().WithMessage(ValidatorMessageConstant.AuxProposta.GuidPropostaInvalido);

            //RuleFor(c => c.RealizarCalculosViaAPI)
            //    .NotNull().WithMessage(ValidatorMessageConstant.AuxProposta.RealizarCalculosViaAPIInvalido);
        }
    }
}
