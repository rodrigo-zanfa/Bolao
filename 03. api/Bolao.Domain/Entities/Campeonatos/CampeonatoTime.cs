using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Campeonatos
{
    public class CampeonatoTime : EntityBase
    {
        public int IdCampeonatoTime { get; set; }
        public int IdCampeonato { get; set; }
        public int IdTime { get; set; }
    }
}
