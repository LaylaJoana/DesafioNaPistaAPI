using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Configuration;
using Persistence.Repositories;
using Domain.Interfaces.Repositories;
using System;

namespace Persistence
{
    public static class PersistenceExtensions
    {        
        public static IServiceCollection SetupPersistenceLayer(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddScoped<DbContext, DesafioNaPistaDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            var postgresDatabaseSettings = configuration.GetSection("Databases");
            var connectionString = postgresDatabaseSettings["ConnectionString"];
            var retryCount = Convert.ToInt32(postgresDatabaseSettings["ConnectionRetryCount"]);
            var retryDelay = Convert.ToInt32(postgresDatabaseSettings["ConnectionRetryDelay"]);

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<DesafioNaPistaDbContext>(options =>
               {
                   options.UseNpgsql(connectionString, npgSqlOptions =>
                   {
                       npgSqlOptions.EnableRetryOnFailure(
                           retryCount,
                           TimeSpan.FromSeconds(retryDelay),
                           null);
                   });
               }, ServiceLifetime.Transient);

            return services;
        }
    }
}
