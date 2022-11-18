using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Campeonatos
{
    public class CampeonatoPartida : EntityBase
    {
        public int IdCampeonatoPartida { get; set; }
        public DateTime DtPartida { get; set; }
        public int IdEstadio { get; set; }
        public int IdCampeonatoTime1 { get; set; }
        public int IdCampeonatoTime2 { get; set; }
        public int? PlacarTime1 { get; set; }
        public int? PlacarTime2 { get; set; }
    }
}
