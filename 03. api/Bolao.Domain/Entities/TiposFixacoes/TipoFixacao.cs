using Bolao.Domain.Entities.MarcasEstruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.TiposFixacoes
{
    public class TipoFixacao : EntityBase
    {
        public TipoFixacao()
        {

        }

        public int IdTipoFixacao { get; private set; }
        public string Descricao { get; private set; }
        public MarcaEstrutura MarcaEstrutura { get; /*private*/ set; }
    }
}
