
using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Geti.Data.Context
{
    public class GetiDbContext : DbContext
    {
        public GetiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Colaborador> Colaboradores { get; set; }
            
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Licenca> Licencas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GetiDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
