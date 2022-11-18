using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Produtos
{
    public class ProdutoTipo
    {
        public ProdutoTipo()
        {

        }

        public ProdutoTipo(int idProdutoTipo)
        {
            IdProdutoTipo = idProdutoTipo;
        }

        public int IdProdutoTipo { get; private set; }
        public string Descricao { get; private set; }
    }
}
