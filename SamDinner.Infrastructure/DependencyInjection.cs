using Microsoft.Extensions.DependencyInjection;
using SamDinner.Application.Common.Interfaces.Authentication;
using SamDinner.Application.Common.Interfaces.Services;
using SamDinner.Infrastructure.Authentication;
using SamDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using SamDinner.Application.Common.Interfaces.Persistence;
using SamDinner.Infrastructure.Persistence;

namespace SamDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        // add the IOptions interface to the DI container
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}