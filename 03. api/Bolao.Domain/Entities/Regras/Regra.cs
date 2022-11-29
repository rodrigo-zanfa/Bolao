using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Regras
{
    public class Regra : EntityBase
    {
        public int IdRegra { get; set; }
        public string Descricao { get; set; }
        public string DescricaoDetalhada { get; set; }
        public int Pontuacao { get; set; }
        public int Ordem { get; set; }
        public string Status { get; set; }
    }
}
