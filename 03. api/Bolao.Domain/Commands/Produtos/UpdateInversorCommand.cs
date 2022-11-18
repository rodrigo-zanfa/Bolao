using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class UpdateInversorCommand : ICommand
    {
        public UpdateInversorCommand(int idInversor, int idMarca, int idFase, int tensaoCA, int tensaoCC, double potenciaSaida, double potenciaMinima, double potenciaMaxima, double potenciaRecomendada, int tensaoMinimaEntrada, int tensaoMinimaLigar, int quantidadeMPPT, int quantidadeStrings, double correnteCA, string tipo, int idFaseConjugada, int idFaseConjugada2, int idFaseConjugada3Trifasica380V, double moduloMinimo, double moduloMaximo, double correnteCurtoCircuito)
        {
            IdInversor = idInversor;
            IdMarca = idMarca;
            IdFase = idFase;
            TensaoCA = tensaoCA;
            TensaoCC = tensaoCC;
            PotenciaSaida = potenciaSaida;
            PotenciaMinima = potenciaMinima;
            PotenciaMaxima = potenciaMaxima;
            PotenciaRecomendada = potenciaRecomendada;
            TensaoMinimaEntrada = tensaoMinimaEntrada;
            TensaoMinimaLigar = tensaoMinimaLigar;
            QuantidadeMPPT = quantidadeMPPT;
            QuantidadeStrings = quantidadeStrings;
            CorrenteCA = correnteCA;
            Tipo = tipo;
            IdFaseConjugada = idFaseConjugada;
            IdFaseConjugada2 = idFaseConjugada2;
            IdFaseConjugada3Trifasica380V = idFaseConjugada3Trifasica380V;
            ModuloMinimo = moduloMinimo;
            ModuloMaximo = moduloMaximo;
            CorrenteCurtoCircuito = correnteCurtoCircuito;
        }

        public int IdInversor { get; set; }
        public int IdMarca { get; set; }
        public int IdFase { get; set; }
        public int TensaoCA { get; set; }
        public int TensaoCC { get; set; }
        public double PotenciaSaida { get; set; }
        public double PotenciaMinima { get; set; }
        public double PotenciaMaxima { get; set; }
        public double PotenciaRecomendada { get; set; }
        public int TensaoMinimaEntrada { get; set; }
        public int TensaoMinimaLigar { get; set; }
        public int QuantidadeMPPT { get; set; }
        public int QuantidadeStrings { get; set; }
        public double CorrenteCA { get; set; }
        public string Tipo { get; set; }
        public int IdFaseConjugada { get; set; }
        public int IdFaseConjugada2 { get; set; }
        public int IdFaseConjugada3Trifasica380V { get; set; }
        public double ModuloMinimo { get; set; }
        public double ModuloMaximo { get; set; }
        public double CorrenteCurtoCircuito { get; set; }
    }
}
