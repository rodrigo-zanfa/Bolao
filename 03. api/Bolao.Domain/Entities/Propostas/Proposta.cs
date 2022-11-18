using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Propostas
{
    public class Proposta : EntityBase
    {
        public int IdTabela { get; set; }
        public string IdDoc { get; set; }
        public int IdStatus { get; set; }
        public int IdSituacao { get; set; }
        public int IdLoja { get; set; }
        public string NrProposta { get; set; }
        public int Versao { get; set; }
        public string NomeCliente { get; set; }
        public string NomeProjeto { get; set; }
        public string IdEstado { get; set; }
        public int IdCidade { get; set; }
        public int IdDimensionamento { get; set; }
        public double PotenciaKwh { get; set; }
        public double EnergiaMediaAnual { get; set; }
        public double ConsumoMensalJan { get; set; }
        public double ConsumoMensalFev { get; set; }
        public double ConsumoMensalMar { get; set; }
        public double ConsumoMensalAbr { get; set; }
        public double ConsumoMensalMai { get; set; }
        public double ConsumoMensalJun { get; set; }
        public double ConsumoMensalJul { get; set; }
        public double ConsumoMensalAgo { get; set; }
        public double ConsumoMensalSet { get; set; }
        public double ConsumoMensalOut { get; set; }
        public double ConsumoMensalNov { get; set; }
        public double ConsumoMensalDez { get; set; }
        public int IdFase { get; set; }
        public int IdTensao { get; set; }
        public int IdModulo { get; set; }
        public int IdOrientacaoTelhado { get; set; }
        public int IdMarca { get; set; }
        public int IdMarcaEstruturaProposta { get; set; }
        public int IdTelhado { get; set; }
        public double PotenciaCalculada { get; set; }
        public int QtdModuloSugerido { get; set; }
        public double PorcProjeto { get; set; }
        public double PorcInstalacao { get; set; }
        public string IncluiMonitoramento { get; set; }
        public string TipoFrete { get; set; }
        public string TipoProposta { get; set; }
        public double ValorKwh { get; set; }
        public double ValorProjetoElsys { get; set; }
        public double ValorProjetoMargem { get; set; }
        public int QtdTotalFileira { get; set; }
        public DateTime VecimentoProjeto { get; set; }
        public double ConsumoUltimaConta { get; set; }
        public bool FlgExcluido { get; set; }
        public string IdUsuario { get; set; }
        public int IdTipoInversor { get; set; }
        public double ValorNFServicoProjeto { get; set; }
        public double ValorNFServicoInstalacao { get; set; }
        public string HabilitaSeguro { get; set; }
        public int IdCondicaoPagto { get; set; }
        public double ValorProjetoFinal { get; set; }
        public int IdStatusProposta { get; set; }
        public int IdUnidadeProposta { get; set; }
        public double ValorDistribuidorBruto { get; set; }
        public double ValorDistribuidorLiquido { get; set; }
        public double PotenciaTotalCalculada { get; set; }
        public string MensagemPotenciaIncompativel { get; set; }
        public string Url { get; set; }
        public string NomeArquivo { get; set; }
    }
}
