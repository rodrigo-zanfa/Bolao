using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Campeonatos
{
    public class GerarPontuacaoPorPartidaCommand : ICommand
    {
        public int IdCampeonatoPartida { get; set; }
    }
}
