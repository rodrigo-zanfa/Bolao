using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities
{
    public class EntityBase : Entity
    {
        [JsonIgnore]
        public string UsuarioInclusao { get; protected set; }
        [JsonIgnore]
        public DateTime DataInclusao { get; protected set; }
        [JsonIgnore]
        public string UsuarioAlteracao { get; /*protected*/ set; }
        [JsonIgnore]
        public DateTime? DataAlteracao { get; protected set; }
    }
}
