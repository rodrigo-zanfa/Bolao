using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.MarcasEstruturas
{
    public class MarcaEstrutura : EntityBase
    {
        public MarcaEstrutura()
        {

        }

        public int IdMarcaEstrutura { get; private set; }
        public string Descricao { get; private set; }
        public string Ativo { get; private set; }
    }
}
