using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pagamento.Domain.Interfaces;
using Pagamento.Service;

namespace Pagamento.Infra.Mapping
{
    public static  class ServiceExtension
    {
        public static IServiceCollection SetupMappingLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPagamentoService, PagamentoService>();
      
            return services;
        }
    }
}
