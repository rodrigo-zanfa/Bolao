using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Campeonatos
{
    public class UpdatePlacarCampeonatoPartidaCommand : ICommand
    {
        public int IdCampeonatoPartida { get; set; }
        public int? PlacarTime1 { get; set; }
        public int? PlacarTime2 { get; set; }
    }
}
