using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Usuarios
{
    public class Usuario : EntityBase
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Senha { get; set; }
        public string UrlImagem { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
