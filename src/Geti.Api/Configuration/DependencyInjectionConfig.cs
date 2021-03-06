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
                services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
                services.AddScoped<IEquipamentoService, EquipamentoService>();
                services.AddScoped<IComentarioRepository, ComentarioRepository>();
                services.AddScoped<IComentarioService, ComentarioService>();
                services.AddScoped<ILicencaRepository, LicencaRepository>();
                services.AddScoped<ILicencaService, LicencaService>();
                services.AddScoped<IEquipamentoLicencaRepository, EquipamentoLicencaRepository>();
                services.AddScoped<IEquipamentoLicencaService, EquipamentoLicencaService>();
                services.AddScoped<ISoftwareRepository, SoftwareRepository>();
                services.AddScoped<ISoftwareService, SoftwareService>();

                services.AddScoped<INotificador, Notificador>();
        
                return services;
            }
    }
}
