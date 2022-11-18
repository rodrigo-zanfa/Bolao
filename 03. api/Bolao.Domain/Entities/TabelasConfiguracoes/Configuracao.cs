namespace Bolao.Domain.Entities.TabelasConfiguracoes
{
    public class Configuracao : EntityBase
    {
        public Configuracao(int idConfiguracao, int quantidadeDiasVencimentoProposta, double porcentagemFrete, double porcentagemImposto, double porcentagemInadimplencia, double porcentagemMarketing, double porcentagemGarantia, double porcentagemSeguro)
        {
            IdConfiguracao = idConfiguracao;
            QuantidadeDiasVencimentoProposta = quantidadeDiasVencimentoProposta;
            PorcentagemFrete = porcentagemFrete;
            PorcentagemImposto = porcentagemImposto;
            PorcentagemInadimplencia = porcentagemInadimplencia;
            PorcentagemMarketing = porcentagemMarketing;
            PorcentagemGarantia = porcentagemGarantia;
            PorcentagemSeguro = porcentagemSeguro;
        }

        public Configuracao()
        {
        }

        public int IdConfiguracao { get; private set; }
        public int QuantidadeDiasVencimentoProposta { get; private set; }
        public double PorcentagemFrete { get; private set; }
        public double PorcentagemImposto { get; private set; }
        public double PorcentagemInadimplencia { get; private set; }
        public double PorcentagemMarketing { get; private set; }
        public double PorcentagemGarantia { get; private set; }
        public double PorcentagemSeguro { get; private set; }
    }
}
