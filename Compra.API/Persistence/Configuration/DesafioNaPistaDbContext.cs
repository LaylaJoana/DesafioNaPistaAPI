using Microsoft.EntityFrameworkCore;
using Persistence.ModelConfiguration;

namespace Persistence.Configuration
{
    public class DesafioNaPistaDbContext : DbContext
    {
        public DesafioNaPistaDbContext(DbContextOptions<DesafioNaPistaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfiguration(new ProdutoModelConfiguration());
            modelBuilder.ApplyConfiguration(new VendaModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
