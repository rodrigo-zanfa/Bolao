using Bolao.Domain.Interfaces.Configs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Configs
{
    public class ApiSettingsAccessor : IApiSettingsAccessor
    {
        private readonly IOptions<ApiSettings> _options;

        public ApiSettingsAccessor(IOptions<ApiSettings> options)
        {
            _options = options;
        }

        public ApiSettings GetSettings()
        {
            return _options.Value;
        }
    }
}
