using Microsoft.Extensions.DependencyInjection;
using SamDinner.Application.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();


            return services;
        }
    }
}
