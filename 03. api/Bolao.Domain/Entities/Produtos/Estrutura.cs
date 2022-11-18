using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Produtos
{
    public class Estrutura : EntityBase
    {
        public Estrutura()
        {

        }

        public Estrutura(int idEstrutura, int quantidade, List<int> idTelhado)
        {
            IdEstrutura = idEstrutura;
            Quantidade = quantidade;
            IdTelhado = idTelhado;
        }

        public int IdEstrutura { get; private set; }
        public int Quantidade { get; private set; }
        public List<int> IdTelhado { get; /*private*/ set; }
    }
}
