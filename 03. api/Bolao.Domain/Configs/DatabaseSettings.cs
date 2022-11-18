using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Configs
{
    public class DatabaseSettings
    {
        public string DB_DATA_SOURCE { get; set; }
        public string DB_INITIAL_CATALOG { get; set; }
        public string DB_USER_ID { get; set; }
        public string DB_PASSWORD { get; set; }
    }
}
