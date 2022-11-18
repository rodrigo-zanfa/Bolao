using Bolao.Domain.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Bolao.API.Configuration
{
    public static class Authentication
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            //var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            //var key = Environment.GetEnvironmentVariable("JWT_KEY");

            var jwtSettingsSection = configuration.GetSection("Jwt");
            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

            var issuer = jwtSettings.JWT_ISSUER;
            var audience = jwtSettings.JWT_AUDIENCE;
            var key = jwtSettings.JWT_KEY;

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = issuer,
                        ValidateAudience = true,
                        ValidAudience = audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidateLifetime = false
                    };
                });

            return services;
        }
    }
}
