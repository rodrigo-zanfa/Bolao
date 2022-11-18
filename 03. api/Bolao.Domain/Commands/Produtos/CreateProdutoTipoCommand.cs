using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class CreateProdutoTipoCommand
    {
        public int IdProdutoTipo { get; set; }
        public string Descricao { get; set; }
    }
}
