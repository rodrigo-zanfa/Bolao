using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Propostas
{
    public class AlterarProdutoQuantidadeCommand : ICommand
    {
        public int IdAux { get; set; }
        public double QtdDesejada { get; set; }
        public string GuidProposta { get; set; }
        //public bool RealizarCalculosViaAPI { get; set; }
    }
}
