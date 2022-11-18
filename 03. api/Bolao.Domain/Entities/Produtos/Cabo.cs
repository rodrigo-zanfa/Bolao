using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Produtos
{
    public class Cabo : EntityBase
    {
        public Cabo()
        {

        }

        public Cabo(int idCabo, int idTipoInversor, string observacao)
        {
            IdCabo = idCabo;
            IdTipoInversor = idTipoInversor;
            Observacao = observacao;
        }

        public int IdCabo { get; private set; }
        public int IdTipoInversor { get; private set; }
        public string Observacao { get; private set; }
    }
}
