using Bolao.Domain.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Interfaces.Configs
{
    public interface IApiSettingsAccessor
    {
        ApiSettings GetSettings();
    }
}
