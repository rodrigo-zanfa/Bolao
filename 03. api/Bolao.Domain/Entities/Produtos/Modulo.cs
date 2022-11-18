using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Produtos
{
    public class Modulo : EntityBase
    {
        public Modulo()
        {

        }

        public Modulo(int idModulo, string descricaoGrid, double potencia, double correnteMaxima, double tensaoMaxima, double correnteCurtoCircuito, double tensaoCircuitoAberto, double coeficiente, int comprimento, int largura, int espessura)
        {
            IdModulo = idModulo;
            DescricaoGrid = descricaoGrid;
            Potencia = potencia;
            CorrenteMaxima = correnteMaxima;
            TensaoMaxima = tensaoMaxima;
            CorrenteCurtoCircuito = correnteCurtoCircuito;
            TensaoCircuitoAberto = tensaoCircuitoAberto;
            Coeficiente = coeficiente;
            Comprimento = comprimento;
            Largura = largura;
            Espessura = espessura;
        }

        public int IdModulo { get; private set; }
        public string DescricaoGrid { get; private set; }
        public double Potencia { get; private set; }
        public double CorrenteMaxima { get; private set; }
        public double TensaoMaxima { get; private set; }
        public double CorrenteCurtoCircuito { get; private set; }
        public double TensaoCircuitoAberto { get; private set; }
        public double Coeficiente { get; private set; }
        public int Comprimento { get; private set; }
        public int Largura { get; private set; }
        public int Espessura { get; private set; }
    }
}
