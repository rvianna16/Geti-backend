using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geti.Data.Mappings
{
    public class SoftwareMapping : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
               .HasColumnType("varchar(2000)");

            builder.HasMany(c => c.Licencas)
                .WithOne(p => p.Software)
                .HasForeignKey(p => p.SoftwareId);

            builder.ToTable("Softwares");
        }
    }
}
