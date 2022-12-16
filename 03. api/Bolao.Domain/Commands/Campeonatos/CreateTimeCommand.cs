using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Campeonatos
{
    public class CreateTimeCommand : ICommand
    {
        public int IdAux { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string UrlImagem { get; set; }
    }
}
