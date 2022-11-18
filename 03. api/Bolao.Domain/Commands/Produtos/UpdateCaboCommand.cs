using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class UpdateCaboCommand : ICommand
    {
        public UpdateCaboCommand(int idCabo, int idTipoInversor, string observacao)
        {
            IdCabo = idCabo;
            IdTipoInversor = idTipoInversor;
            Observacao = observacao;
        }

        public int IdCabo { get; set; }
        public int IdTipoInversor { get; set; }
        public string Observacao { get; set; }
    }
}
