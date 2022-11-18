using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.ClassesParceiros
{
    public class ClasseParceiro : EntityBase
    {
        public int IdClasseParceiro { get; private set; }
        public string Descricao { get; private set; }
        public double PorcentagemElsys { get; private set; }
    }
}
