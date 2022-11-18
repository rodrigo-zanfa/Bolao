using Dapper.FluentMap.Mapping;
using Bolao.Domain.Entities.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Mappers.Propostas
{
    public class AuxPropostaGridMap : EntityMap<AuxPropostaGrid>
    {
        public AuxPropostaGridMap()
        {
            Map(p => p.IdAux)
                .ToColumn("Id_Aux", false);

            Map(p => p.IdLoja)
                .ToColumn("Id_Loja", false);

            Map(p => p.IdUsuario)
                .ToColumn("Id_Usuario", false);

            //Map(p => p.Descricao)
            //    .ToColumn("Descricao", false);

            //Map(p => p.PrecoUnitario)
            //    .ToColumn("PrecoUnitario", false);

            //Map(p => p.Quantidade)
            //    .ToColumn("Quantidade", false);

            //Map(p => p.Subtotal)
            //    .ToColumn("Subtotal", false);

            //Map(p => p.PrecoUnitarioComMargem)
            //    .ToColumn("PrecoUnitarioComMargem", false);

            //Map(p => p.QtdDesejada)
            //    .ToColumn("QtdDesejada", false);

            //Map(p => p.SubtotalComMargem)
            //    .ToColumn("SubtotalComMargem", false);

            //Map(p => p.Potencia)
            //    .ToColumn("Potencia", false);

            //Map(p => p.QtdModulo)
            //    .ToColumn("QtdModulo", false);

            //Map(p => p.TotalSubtotal)
            //    .ToColumn("TotalSubtotal", false);

            //Map(p => p.TotalSubtotalComMargem)
            //    .ToColumn("TotalSubtotalComMargem", false);

            Map(p => p.PorcDesconto)
                .ToColumn("Porc_Desconto", false);

            //Map(p => p.PrecoUnitarioDesconto)
            //    .ToColumn("PrecoUnitarioDesconto", false);

            Map(p => p.IdTabela)
                .ToColumn("Id_Tabela", false);

            Map(p => p.CodProduto)
                .ToColumn("Cod_Produto", false);

            Map(p => p.ValorNFServicoProjeto)
                .ToColumn("Valor_NF_Servico_Projeto", false);

            Map(p => p.ValorNFServicoInstalacao)
                .ToColumn("Valor_NF_Servico_Instalacao", false);

            //Map(p => p.ValorProjetoFinal)
            //    .ToColumn("ValorProjetoFinal", false);

            //Map(p => p.DescricaoTipo)
            //    .ToColumn("DescricaoTipo", false);

            //Map(p => p.Modelo)
            //    .ToColumn("Modelo", false);

            //Map(p => p.Marca)
            //    .ToColumn("Marca", false);

            //Map(p => p.Unidade)
            //    .ToColumn("Unidade", false);

            //Map(p => p.GuidProposta)
            //    .ToColumn("GuidProposta", false);

            //Map(p => p.PrecoUnitarioFixo)
            //    .ToColumn("PrecoUnitarioFixo", false);


            #region Propriedades usadas somente para retorno de dados, não fazem parte da tabela

            //Map(p => p.PotenciaTotalCalculada)
            //    .ToColumn("PotenciaTotalCalculada", false);

            Map(p => p.IdCondicaoPagto)
                .ToColumn("Id_CondicaoPagto", false);

            #endregion


            #region Propriedades usadas para realizar e armazenar os cálculos

            //Map(p => p.FretePorcentagem)
            //    .ToColumn("FretePorcentagem", false);

            //Map(p => p.FreteValor)
            //    .ToColumn("FreteValor", false);

            //Map(p => p.FreteValorSemCartao)
            //    .ToColumn("FreteValorSemCartao", false);


            //Map(p => p.ImpostoPorcentagem)
            //    .ToColumn("ImpostoPorcentagem", false);

            //Map(p => p.ImpostoValor)
            //    .ToColumn("ImpostoValor", false);

            //Map(p => p.ImpostoValorSemCartao)
            //    .ToColumn("ImpostoValorSemCartao", false);


            //Map(p => p.InadimplenciaPorcentagem)
            //    .ToColumn("InadimplenciaPorcentagem", false);

            //Map(p => p.InadimplenciaValor)
            //    .ToColumn("InadimplenciaValor", false);

            //Map(p => p.InadimplenciaValorSemCartao)
            //    .ToColumn("InadimplenciaValorSemCartao", false);


            //Map(p => p.MarketingPorcentagem)
            //    .ToColumn("MarketingPorcentagem", false);

            //Map(p => p.MarketingValor)
            //    .ToColumn("MarketingValor", false);

            //Map(p => p.MarketingValorSemCartao)
            //    .ToColumn("MarketingValorSemCartao", false);


            //Map(p => p.GarantiaPorcentagem)
            //    .ToColumn("GarantiaPorcentagem", false);

            //Map(p => p.GarantiaValor)
            //    .ToColumn("GarantiaValor", false);

            //Map(p => p.GarantiaValorSemCartao)
            //    .ToColumn("GarantiaValorSemCartao", false);


            //Map(p => p.SeguroPorcentagem)
            //    .ToColumn("SeguroPorcentagem", false);

            //Map(p => p.SeguroValor)
            //    .ToColumn("SeguroValor", false);

            //Map(p => p.SeguroValorSemCartao)
            //    .ToColumn("SeguroValorSemCartao", false);


            //Map(p => p.CartaoPorcentagem)
            //    .ToColumn("CartaoPorcentagem", false);

            //Map(p => p.CartaoValor)
            //    .ToColumn("CartaoValor", false);


            //Map(p => p.MargemElsysPorcentagem)
            //    .ToColumn("MargemElsysPorcentagem", false);

            //Map(p => p.MargemElsysValor)
            //    .ToColumn("MargemElsysValor", false);

            //Map(p => p.MargemElsysValorSemCartao)
            //    .ToColumn("MargemElsysValorSemCartao", false);


            //Map(p => p.MargemDistribuidorPorcentagem)
            //    .ToColumn("MargemDistribuidorPorcentagem", false);

            //Map(p => p.MargemDistribuidorValor)
            //    .ToColumn("MargemDistribuidorValor", false);

            //Map(p => p.MargemDistribuidorValorSemCartao)
            //    .ToColumn("MargemDistribuidorValorSemCartao", false);


            //Map(p => p.ValorUnitarioProduto)
            //    .ToColumn("ValorUnitarioProduto", false);

            //Map(p => p.ValorUnitarioBaseCalculo)
            //    .ToColumn("ValorUnitarioBaseCalculo", false);

            //Map(p => p.ValorUnitarioBaseCalculoSemCartao)
            //    .ToColumn("ValorUnitarioBaseCalculoSemCartao", false);


            //Map(p => p.ValorBrutoServicos)
            //    .ToColumn("ValorBrutoServicos", false);

            //Map(p => p.ValorRepasseLiquidoServicos)
            //    .ToColumn("ValorRepasseLiquidoServicos", false);

            //Map(p => p.ValorAdicionalDevidoRepasseServicos)
            //    .ToColumn("ValorAdicionalDevidoRepasseServicos", false);

            //Map(p => p.ValorAdicionalDevidoRepasseServicosSemCartao)
            //    .ToColumn("ValorAdicionalDevidoRepasseServicosSemCartao", false);


            //Map(p => p.ValorRepasseLiquidoComissao)
            //    .ToColumn("ValorRepasseLiquidoComissao", false);

            //Map(p => p.ValorRepasseLiquidoComissaoSemCartao)
            //    .ToColumn("ValorRepasseLiquidoComissaoSemCartao", false);

            //Map(p => p.ValorAdicionalDevidoRepasseComissao)
            //    .ToColumn("ValorAdicionalDevidoRepasseComissao", false);

            //Map(p => p.ValorAdicionalDevidoRepasseComissaoSemCartao)
            //    .ToColumn("ValorAdicionalDevidoRepasseComissaoSemCartao", false);


            #endregion
        }
    }
}
