using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Configs
{
    public class ApiSettings
    {
        public DatabaseSettings Database { get; set; }
        public JwtSettings Jwt { get; set; }
    }
}
