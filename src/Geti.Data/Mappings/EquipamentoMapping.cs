using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geti.Data.Mappings
{
    public class EquipamentoMapping : IEntityTypeConfiguration<Equipamento>
    {        
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Patrimonio)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(4000)");

            builder.Property(p => p.NotaFiscal)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Modelo)
               .HasColumnType("varchar(50)");

            builder.Property(p => p.Armazenamento)
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Processador)
               .HasColumnType("varchar(100)");

            builder.Property(p => p.IP)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.StatusEquipamento)
                .IsRequired()
                .HasColumnType("varchar(15)");     

            builder.HasMany(c => c.Comentarios)
               .WithOne(c => c.Equipamento)
               .HasForeignKey(c => c.EquipamentoId);

            builder.ToTable("Equipamentos");
        }

    }
}
