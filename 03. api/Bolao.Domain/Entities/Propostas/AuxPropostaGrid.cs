using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Propostas
{
    public class AuxPropostaGrid : EntityBase
    {
        public int IdAux { get; set; }
        public int IdLoja { get; set; }
        public string IdUsuario { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public double Quantidade { get; set; }
        public double Subtotal { get; set; }
        public double PrecoUnitarioComMargem { get; set; }
        public double QtdDesejada { get; set; }
        public double SubtotalComMargem { get; set; }
        public double Potencia { get; set; }
        public double QtdModulo { get; set; }
        public double TotalSubtotal { get; set; }
        public double TotalSubtotalComMargem { get; set; }
        public double PorcDesconto { get; set; }
        public double PrecoUnitarioDesconto { get; set; }
        public int IdTabela { get; set; }
        public string CodProduto { get; set; }
        public double ValorNFServicoProjeto { get; set; }
        public double ValorNFServicoInstalacao { get; set; }
        public double ValorProjetoFinal { get; set; }
        public string DescricaoTipo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Unidade { get; set; }
        public string GuidProposta { get; set; }
        public double PrecoUnitarioFixo { get; set; }


        #region Propriedades usadas somente para retorno de dados, não fazem parte da tabela

        public double PotenciaTotalCalculada { get; set; }
        public int IdCondicaoPagto { get; set; }

        #endregion


        #region Propriedades usadas para realizar e armazenar os cálculos

        public double FretePorcentagem { get; set; }
        public double FreteValor { get; set; }
        public double FreteValorSemCartao { get; set; }

        public double ImpostoPorcentagem { get; set; }
        public double ImpostoValor { get; set; }
        public double ImpostoValorSemCartao { get; set; }

        public double InadimplenciaPorcentagem { get; set; }
        public double InadimplenciaValor { get; set; }
        public double InadimplenciaValorSemCartao { get; set; }

        public double MarketingPorcentagem { get; set; }
        public double MarketingValor { get; set; }
        public double MarketingValorSemCartao { get; set; }

        public double GarantiaPorcentagem { get; set; }
        public double GarantiaValor { get; set; }
        public double GarantiaValorSemCartao { get; set; }

        public double SeguroPorcentagem { get; set; }
        public double SeguroValor { get; set; }
        public double SeguroValorSemCartao { get; set; }

        public double CartaoPorcentagem { get; set; }
        public double CartaoValor { get; set; }

        public double MargemElsysPorcentagem { get; set; }
        public double MargemElsysValor { get; set; }
        public double MargemElsysValorSemCartao { get; set; }

        public double MargemDistribuidorPorcentagem { get; set; }
        public double MargemDistribuidorValor { get; set; }
        public double MargemDistribuidorValorSemCartao { get; set; }

        public double ValorUnitarioProduto { get; set; }
        public double ValorUnitarioBaseCalculo { get; set; }
        public double ValorUnitarioBaseCalculoSemCartao { get; set; }

        public double ValorBrutoServicos { get; set; }
        public double ValorRepasseLiquidoServicos { get; set; }
        public double ValorAdicionalDevidoRepasseServicos { get; set; }
        public double ValorAdicionalDevidoRepasseServicosSemCartao { get; set; }

        public double ValorRepasseLiquidoComissao { get; set; }
        public double ValorRepasseLiquidoComissaoSemCartao { get; set; }
        public double ValorAdicionalDevidoRepasseComissao { get; set; }
        public double ValorAdicionalDevidoRepasseComissaoSemCartao { get; set; }

        #endregion
    }
}
