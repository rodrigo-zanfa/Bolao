using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Campeonatos
{
    public class Time : EntityBase
    {
        public int IdTime { get; set; }
        public int IdTimeAux { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string UrlImagem { get; set; }
    }
}
