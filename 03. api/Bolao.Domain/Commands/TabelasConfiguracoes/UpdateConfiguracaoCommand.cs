using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.TabelasConfiguracoes
{
    public class UpdateConfiguracaoCommand : ICommand
    {
        public int IdConfiguracao { get; set; }
        public int QuantidadeDiasVencimentoProposta { get; set; }
        public double PorcentagemFrete { get; set; }
        public double PorcentagemImposto { get; set; }
        public double PorcentagemInadimplencia { get; set; }
        public double PorcentagemMarketing { get; set; }
        public double PorcentagemGarantia { get; set; }
        public double PorcentagemSeguro { get; set; }
    }
}
