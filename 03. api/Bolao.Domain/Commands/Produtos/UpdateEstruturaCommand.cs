using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class UpdateEstruturaCommand : ICommand
    {
        public UpdateEstruturaCommand(int idEstrutura, int quantidade, List<int> idTelhado)
        {
            IdEstrutura = idEstrutura;
            Quantidade = quantidade;
            IdTelhado = idTelhado;
        }

        public int IdEstrutura { get; set; }
        public int Quantidade { get; set; }
        public List<int> IdTelhado { get; set; }
    }
}
