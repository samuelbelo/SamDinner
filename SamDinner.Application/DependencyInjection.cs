using Microsoft.Extensions.DependencyInjection;
using SamDinner.Application.Services.Authentication;

namespace SamDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}