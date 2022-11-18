using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Propostas
{
    public class AuxPropostaCartao : EntityBase
    {
        public int Id { get; set; }
        public int IdOperadora { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double Taxa { get; set; }
        public string IdUsuario { get; set; }
        public int IdLoja { get; set; }
        public string GuidProposta { get; set; }
    }
}
