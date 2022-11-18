using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.TabelasConfiguracoes
{
    public class UpdateCartaoCreditoCommand : ICommand
    {
        public int IdCartaoCredito { get; set; }
        public string Bandeira { get; set; }
        public double FormatoPagamentoUmaParcela { get; set; }
        public double FormatoPagamentoDuasAteSeisParcelas { get; set; }
        public double FormatoPagamentoSeteAteDozeParcelas { get; set; }
        public double Taxa01X { get; set; }
        public double Taxa02X { get; set; }
        public double Taxa03X { get; set; }
        public double Taxa04X { get; set; }
        public double Taxa05X { get; set; }
        public double Taxa06X { get; set; }
        public double Taxa07X { get; set; }
        public double Taxa08X { get; set; }
        public double Taxa09X { get; set; }
        public double Taxa10X { get; set; }
        public double Taxa11X { get; set; }
        public double Taxa12X { get; set; }
    }
}
