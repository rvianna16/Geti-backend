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
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.NotaFiscal)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.HasOne(c => c.Colaborador)
                .WithMany(e => e.Equipamentos)
                .HasForeignKey(c => c.ColaboradorId);

            builder.HasMany(l => l.Licencas)
                .WithMany(e => e.Equipamentos);


            builder.ToTable("Equipamentos");
        }

    }
}
