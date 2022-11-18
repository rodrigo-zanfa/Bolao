﻿using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Propostas
{
    public class AlterarCondicaoPagtoCommand : ICommand
    {
        public int IdCondicaoPagto { get; set; }
        public int IdOperadora { get; set; }
        public int QuantidadeParcelas { get; set; }
        public string IdUsuario { get; set; }
        public int IdLoja { get; set; }
        public string GuidProposta { get; set; }
        //public bool RealizarCalculosViaAPI { get; set; }
    }
}
