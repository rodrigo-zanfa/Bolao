﻿using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Campeonatos
{
    public class CreateCampeonatoPartidaCommand : ICommand
    {
        public DateTime DtPartida { get; set; }
        public int IdEstadio { get; set; }
        public int IdCampeonatoTime1 { get; set; }
        public int IdCampeonatoTime2 { get; set; }
        public int Peso { get; set; }
    }
}
