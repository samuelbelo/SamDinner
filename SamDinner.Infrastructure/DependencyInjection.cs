using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SamDinner.Application.Common.Interfaces.Authentication;
using SamDinner.Application.Common.Services;
using SamDinner.Infrastructure.Authentication;
using SamDinner.Infrastructure.Services;

namespace SamDinner.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
