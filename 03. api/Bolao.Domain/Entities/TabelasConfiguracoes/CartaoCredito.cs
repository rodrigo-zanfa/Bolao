namespace Bolao.Domain.Entities.TabelasConfiguracoes
{
    public class CartaoCredito : EntityBase
    {
        public int IdCartaoCredito { get; private set; }
        public string Bandeira { get; private set; }
        public double FormatoPagamentoUmaParcela { get; private set; }
        public double FormatoPagamentoDuasAteSeisParcelas { get; private set; }
        public double FormatoPagamentoSeteAteDozeParcelas { get; private set; }
        public double Taxa01X { get; private set; }
        public double Taxa02X { get; private set; }
        public double Taxa03X { get; private set; }
        public double Taxa04X { get; private set; }
        public double Taxa05X { get; private set; }
        public double Taxa06X { get; private set; }
        public double Taxa07X { get; private set; }
        public double Taxa08X { get; private set; }
        public double Taxa09X { get; private set; }
        public double Taxa10X { get; private set; }
        public double Taxa11X { get; private set; }
        public double Taxa12X { get; private set; }
    }
}
