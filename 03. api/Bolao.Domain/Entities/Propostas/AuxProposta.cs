using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Propostas
{
    public class AuxProposta : EntityBase
    {
        public int IdTabela { get; set; }
        public int? IdProposta { get; set; }
        public int? IdLoja { get; set; }
        public string NomeProjeto { get; set; }
        public string IdEstado { get; set; }
        public int? IdCidade { get; set; }
        public int? IdDimensionamento { get; set; }
        public double? PotenciaKwh { get; set; }
        public double? EnergiaMediaAnual { get; set; }
        public double? ConsumoMensalJan { get; set; }
        public double? ConsumoMensalFev { get; set; }
        public double? ConsumoMensalMar { get; set; }
        public double? ConsumoMensalAbr { get; set; }
        public double? ConsumoMensalMai { get; set; }
        public double? ConsumoMensalJun { get; set; }
        public double? ConsumoMensalJul { get; set; }
        public double? ConsumoMensalAgo { get; set; }
        public double? ConsumoMensalSet { get; set; }
        public double? ConsumoMensalOut { get; set; }
        public double? ConsumoMensalNov { get; set; }
        public double? ConsumoMensalDez { get; set; }
        public int? IdFase { get; set; }
        public int? IdTensao { get; set; }
        public int? IdModulo { get; set; }
        public int? IdOrientacaoTelhado { get; set; }
        public int? IdMarca { get; set; }
        public int? IdMarcaEstrutura { get; set; }
        public int? IdTelhado { get; set; }
        public double? PotenciaCalculada { get; set; }
        public double? QtdModuloSugerido { get; set; }
        public double? PorcProjeto { get; set; }
        public double? PorcInstalacao { get; set; }
        public string IncluiMonitoramento { get; set; }
        public string TipoFrete { get; set; }
        public string TipoProposta { get; set; }
        public double? ValorKwh { get; set; }
        public double? ValorProjetoElsys { get; set; }
        public double? ValorProjetoMargem { get; set; }
        public string IdUsuario { get; set; }
        public double? ValorNFServicoProjeto { get; set; }
        public double? ValorNFServicoInstalacao { get; set; }
        public int? IdTipoInversor { get; set; }
        public string HabilitaSeguro { get; set; }
        public int? IdCondicaoPagto { get; set; }
        public double? ValorProjetoFinal { get; set; }
        public int? IdUnidadeProposta { get; set; }
        public double? ValorDistribuidorBruto { get; set; }
        public double? ValorDistribuidorLiquido { get; set; }
        public string GuidProposta { get; set; }
        public double? PotenciaTotalCalculada { get; set; }
    }
}
