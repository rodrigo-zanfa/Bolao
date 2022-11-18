using Bolao.Domain.Commands.TabelasConfiguracoes;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.TabelasConfiguracoes
{
    public class UpdateConfiguracaoCommandValidator : AbstractValidator<UpdateConfiguracaoCommand>
    {
        public UpdateConfiguracaoCommandValidator()
        {
            RuleFor(c => c.IdConfiguracao)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Configuracao.IdConfiguracaoInvalido);

            RuleFor(c => c.QuantidadeDiasVencimentoProposta)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Configuracao.QuantidadeDiasVencimentoPropostaInvalida);

            RuleFor(c => c.PorcentagemFrete)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.Configuracao.PorcentagemFreteInvalida);

            RuleFor(c => c.PorcentagemImposto)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.Configuracao.PorcentagemImpostoInvalida);

            RuleFor(c => c.PorcentagemInadimplencia)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.Configuracao.PorcentagemInadimplenciaInvalida);

            RuleFor(c => c.PorcentagemMarketing)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.Configuracao.PorcentagemMarketingInvalida);

            RuleFor(c => c.PorcentagemGarantia)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.Configuracao.PorcentagemGarantiaInvalida);

            RuleFor(c => c.PorcentagemSeguro)
                .GreaterThanOrEqualTo(0).WithMessage(ValidatorMessageConstant.Configuracao.PorcentagemSeguroInvalida);
        }
    }
}
