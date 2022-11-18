using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class UpdateModuloCommand : ICommand
    {
        public UpdateModuloCommand(int idModulo, string descricaoGrid, double potencia, double correnteMaxima, double tensaoMaxima, double correnteCurtoCircuito, double tensaoCircuitoAberto, double coeficiente, int comprimento, int largura, int espessura)
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

        public int IdModulo { get; set; }
        public string DescricaoGrid { get; set; }
        public double Potencia { get; set; }
        public double CorrenteMaxima { get; set; }
        public double TensaoMaxima { get; set; }
        public double CorrenteCurtoCircuito { get; set; }
        public double TensaoCircuitoAberto { get; set; }
        public double Coeficiente { get; set; }
        public int Comprimento { get; set; }
        public int Largura { get; set; }
        public int Espessura { get; set; }
    }
}
