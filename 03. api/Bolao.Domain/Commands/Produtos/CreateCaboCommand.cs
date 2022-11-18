using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class CreateCaboCommand : ICommand
    {
        public CreateCaboCommand(int idTipoInversor, string observacao)
        {
            IdTipoInversor = idTipoInversor;
            Observacao = observacao;
        }

        public int IdTipoInversor { get; set; }
        public string Observacao { get; set; }
    }
}
