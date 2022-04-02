
using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Geti.Data.Context
{
    public class GetiDbContext : DbContext
    {
        public GetiDbContext(DbContextOptions<GetiDbContext> options) : base(options) { }
        public DbSet<Colaborador> Colaboradores { get; set; }            
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<EquipamentoLicenca> EquipamentoLicenca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GetiDbContext).Assembly);

            modelBuilder.Entity<EquipamentoLicenca>()
                .HasOne(el => el.Equipamento)
                .WithMany(el => el.Licencas)
                .HasForeignKey(el => el.EquipamentoId);

            modelBuilder.Entity<EquipamentoLicenca>()
                .HasOne(el => el.Licenca)
                .WithMany(el => el.Equipamentos)
                .HasForeignKey(el => el.LicencaId);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
