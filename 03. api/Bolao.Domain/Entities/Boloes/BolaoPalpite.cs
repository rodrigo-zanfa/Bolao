using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Boloes
{
    public class BolaoPalpite : EntityBase
    {
        public int IdBolaoPalpite { get; set; }
        public int IdBolaoUsuario { get; set; }
        public int IdCampeonatoPartida { get; set; }
        public int PlacarTime1 { get; set; }
        public int PlacarTime2 { get; set; }
        public DateTime DtCadastro { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public DateTime? DtPontuacao { get; set; }
        public int? IdRegra { get; set; }
        public int? Pontuacao { get; set; }
    }
}
