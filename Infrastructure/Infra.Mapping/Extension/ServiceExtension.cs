
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using Service.Servicies;

namespace Infra.Mapping.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection SetupMappingLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupPersistenceLayer(configuration);

            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IVendaService, VendaService>();
            return services;
        }
    }
}
