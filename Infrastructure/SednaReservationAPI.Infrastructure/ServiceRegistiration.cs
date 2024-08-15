using Microsoft.Extensions.DependencyInjection;
using SednaReservationAPI.Application.Abstractions.Services.Configurations;
using SednaReservationAPI.Application.Abstractions.Token;
using SednaReservationAPI.Infrastructure.Services;
using SednaReservationAPI.Infrastructure.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
