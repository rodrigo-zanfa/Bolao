using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class CreateEstruturaCommand : ICommand
    {
        public CreateEstruturaCommand(int quantidade, List<int> idTelhado)
        {
            Quantidade = quantidade;
            IdTelhado = idTelhado;
        }

        public int Quantidade { get; set; }
        public List<int> IdTelhado { get; set; }
    }
}
