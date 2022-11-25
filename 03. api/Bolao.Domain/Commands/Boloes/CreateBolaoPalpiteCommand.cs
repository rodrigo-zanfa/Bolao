using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Boloes
{
    public class CreateBolaoPalpiteCommand : ICommand
    {
        public int IdBolaoUsuario { get; set; }
        public int IdCampeonatoPartida { get; set; }
        public int PlacarTime1 { get; set; }
        public int PlacarTime2 { get; set; }
    }
}
