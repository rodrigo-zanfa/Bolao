using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Propostas
{
    public class AuxPropostaServico : EntityBase
    {
        public int Id { get; set; }
        public double ValorProjeto { get; set; }
        public double ValorInstalacao { get; set; }
        public string IdUsuario { get; set; }
        public int IdLoja { get; set; }
        public string GuidProposta { get; set; }
    }
}
