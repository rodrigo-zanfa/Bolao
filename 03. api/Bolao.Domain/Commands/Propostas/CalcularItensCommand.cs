using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Propostas
{
    public class CalcularItensCommand : ICommand
    {
        public int IdLoja { get; set; }
        public string NomeProjeto { get; set; }
        public string IdEstado { get; set; }
        public int IdCidade { get; set; }
        public int IdDimensionamento { get; set; }
        public double PotenciaKwh { get; set; }
        public double PotenciaCalculada { get; set; }
        public double? EnergiaMedia { get; set; }
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
        public int IdMarca { get; set; }
        public int IdMarcaEstrutura { get; set; }
        public string IncluiMonitoramento { get; set; }
        public string TipoFrete { get; set; }
        public string IdUsuario { get; set; }
        public int QtdModulo { get; set; }
        public int IdTipoInversor { get; set; }
        public bool HabilitaSeguro { get; set; }
        public int TipoCondicaoPagto { get; set; }
        public string GuidProposta { get; set; }
        public bool RealizarCalculosViaAPI { get; set; }
    }
}
