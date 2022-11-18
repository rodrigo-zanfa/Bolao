using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Campeonatos
{
    public class Campeonato : EntityBase
    {
        public int IdCampeonato { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string UrlImagem { get; set; }
        public string Status { get; set; }
    }
}
