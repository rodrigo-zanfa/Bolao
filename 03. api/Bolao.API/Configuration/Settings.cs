using Bolao.Domain.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Configuration
{
    public static class Settings
    {
        public static IServiceCollection AddCustomSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ApiSettings>(configuration);

            return services;
        }
    }
}
