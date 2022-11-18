using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Produtos
{
    public class Inversor : EntityBase
    {
        public Inversor()
        {

        }

        public Inversor(int idInversor, int idMarca, int idFase, int tensaoCA, int tensaoCC, double potenciaSaida, double potenciaMinima, double potenciaMaxima, double potenciaRecomendada, int tensaoMinimaEntrada, int tensaoMinimaLigar, int quantidadeMPPT, int quantidadeStrings, double correnteCA, string tipo, int idFaseConjugada, int idFaseConjugada2, int idFaseConjugada3Trifasica380V, double moduloMinimo, double moduloMaximo, double correnteCurtoCircuito)
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

        public int IdInversor { get; private set; }
        public int IdMarca { get; private set; }
        public int IdFase { get; private set; }
        public int TensaoCA { get; private set; }
        public int TensaoCC { get; private set; }
        public double PotenciaSaida { get; private set; }
        public double PotenciaMinima { get; private set; }
        public double PotenciaMaxima { get; private set; }
        public double PotenciaRecomendada { get; private set; }
        public int TensaoMinimaEntrada { get; private set; }
        public int TensaoMinimaLigar { get; private set; }
        public int QuantidadeMPPT { get; private set; }
        public int QuantidadeStrings { get; private set; }
        public double CorrenteCA { get; private set; }
        public string Tipo { get; private set; }
        public int IdFaseConjugada { get; private set; }
        public int IdFaseConjugada2 { get; private set; }
        public int IdFaseConjugada3Trifasica380V { get; private set; }
        public double ModuloMinimo { get; private set; }
        public double ModuloMaximo { get; private set; }
        public double CorrenteCurtoCircuito { get; private set; }
    }
}
