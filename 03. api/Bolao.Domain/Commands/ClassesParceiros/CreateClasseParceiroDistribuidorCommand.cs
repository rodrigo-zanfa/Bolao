using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.ClassesParceiros
{
    public class CreateClasseParceiroDistribuidorCommand : ICommand
    {
        public int IdLoja { get; set; }
        public int IdClasseParceiro { get; set; }
        public double PorcentagemParceiro { get; set; }
    }
}
