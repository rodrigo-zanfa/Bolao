using Bolao.Domain.Commands.Produtos;
using Bolao.Domain.Enums.Produtos;
using Bolao.Service.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Produtos
{
    public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
    {
        public CreateProdutoCommandValidator()
        {
            RuleFor(c => c.ProdutoTipo.IdProdutoTipo)
                .InclusiveBetween(Enum.GetValues(typeof(ProdutoTipoEnum)).Cast<int>().Min(), Enum.GetValues(typeof(ProdutoTipoEnum)).Cast<int>().Max()).WithMessage(ValidatorMessageConstant.Produto.IdProdutoTipo);

            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.CodigoInvalido)
                .Length(14, 19).WithMessage(ValidatorMessageConstant.Produto.CodigoInvalido)
                .Must(c1 => c1.IsValidCodigo()).WithMessage(ValidatorMessageConstant.Produto.CodigoInvalido);

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.DescricaoInvalida)
                .Length(1, 100).WithMessage(ValidatorMessageConstant.Produto.DescricaoInvalida);

            When(c => !string.IsNullOrEmpty(c.Marca), () =>
            {
                RuleFor(c => c.Marca)
                    .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.MarcaInvalida)
                    .Length(1, 20).WithMessage(ValidatorMessageConstant.Produto.MarcaInvalida);

                RuleFor(c => c.Modelo)
                    .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.ModeloObrigatorio)
                    .Length(1, 20).WithMessage(ValidatorMessageConstant.Produto.ModeloInvalido);
            });

            When(c => !string.IsNullOrEmpty(c.Modelo), () =>
            {
                RuleFor(c => c.Modelo)
                    .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.ModeloInvalido)
                    .Length(1, 20).WithMessage(ValidatorMessageConstant.Produto.ModeloInvalido);

                RuleFor(c => c.Marca)
                    .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.MarcaObrigatoria)
                    .Length(1, 20).WithMessage(ValidatorMessageConstant.Produto.MarcaInvalida);
            });

            When(c => !string.IsNullOrEmpty(c.Unidade), () =>
            {
                RuleFor(c => c.Unidade)
                    .NotEmpty().WithMessage(ValidatorMessageConstant.Produto.UnidadeInvalida)
                    .Length(1, 3).WithMessage(ValidatorMessageConstant.Produto.UnidadeInvalida);
            });

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage(ValidatorMessageConstant.Produto.ValorInvalido);

            When(c => c.ProdutoTipo.IdProdutoTipo == (int)ProdutoTipoEnum.Estrutura, () =>
            {
                RuleFor(c => c.Estrutura)
                    .NotNull().WithMessage(ValidatorMessageConstant.Produto.EstruturaInvalida);

                RuleFor(c => c.Estrutura)
                    .SetValidator(new CreateEstruturaCommandValidator());
            });

            When(c => c.ProdutoTipo.IdProdutoTipo == (int)ProdutoTipoEnum.Inversor, () =>
            {
                RuleFor(c => c.Inversor)
                    .NotNull().WithMessage(ValidatorMessageConstant.Produto.InversorInvalido);

                RuleFor(c => c.Inversor)
                    .SetValidator(new CreateInversorCommandValidator());
            });

            When(c => c.ProdutoTipo.IdProdutoTipo == (int)ProdutoTipoEnum.Modulo, () =>
            {
                RuleFor(c => c.Modulo)
                    .NotNull().WithMessage(ValidatorMessageConstant.Produto.ModuloInvalido);

                RuleFor(c => c.Modulo)
                    .SetValidator(new CreateModuloCommandValidator());
            });
        }
    }
}
