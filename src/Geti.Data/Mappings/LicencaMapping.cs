using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geti.Data.Mappings
{
    public class LicencaMapping : IEntityTypeConfiguration<Licenca>
    {
        public void Configure(EntityTypeBuilder<Licenca> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Chave)
                .IsRequired()
                .HasColumnType("varchar(100)");                        

            builder.ToTable("Licencas");
        }

    }
}
