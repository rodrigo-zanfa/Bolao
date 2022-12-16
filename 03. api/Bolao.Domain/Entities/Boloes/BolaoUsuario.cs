using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Boloes
{
    public class BolaoUsuario : EntityBase
    {
        public int IdBolaoUsuario { get; set; }
        public int IdBolao { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DtInscricao { get; set; }
    }
}
