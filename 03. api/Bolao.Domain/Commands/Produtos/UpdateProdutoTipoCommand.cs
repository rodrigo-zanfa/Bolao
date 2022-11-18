using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class UpdateProdutoTipoCommand
    {
        public int IdProdutoTipo { get; set; }
        public string Descricao { get; set; }
    }
}
