using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Configs
{
    public class JwtSettings
    {
        public string JWT_ISSUER { get; set; }
        public string JWT_AUDIENCE { get; set; }
        public string JWT_KEY { get; set; }
    }
}
