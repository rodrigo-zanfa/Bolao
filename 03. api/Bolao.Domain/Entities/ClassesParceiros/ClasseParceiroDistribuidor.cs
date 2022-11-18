using Bolao.Domain.Entities.Lojas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.ClassesParceiros
{
    public class ClasseParceiroDistribuidor : EntityBase
    {
        public int IdClasseParceiroDistribuidor { get; private set; }
        public Loja Loja { get; /*private*/ set; }
        public int IdClasseParceiro { get; /*private*/ set; }
        public double PorcentagemParceiro { get; private set; }
    }
}
