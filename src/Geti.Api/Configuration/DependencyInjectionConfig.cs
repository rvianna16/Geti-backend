using Geti.Business.Interfaces;
using Geti.Business.Notificacoes;
using Geti.Business.Services;
using Geti.Data.Context;
using Geti.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Geti.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
            {

                services.AddScoped<GetiDbContext>();
                services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
                services.AddScoped<IColaboradorService, ColaboradorService>();

                services.AddScoped<INotificador, Notificador>();


            return services;
            }
    }
}
