using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bolao.API.Configuration
{
    public static class AutoMapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
