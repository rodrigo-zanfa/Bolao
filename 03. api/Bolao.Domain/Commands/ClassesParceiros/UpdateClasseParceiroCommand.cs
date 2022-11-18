using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.ClassesParceiros
{
    public class UpdateClasseParceiroCommand : ICommand
    {
        public int IdClasseParceiro { get; set; }
        public string Descricao { get; set; }
        public double PorcentagemElsys { get; set; }
    }
}
