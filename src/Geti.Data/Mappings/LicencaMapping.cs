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

            builder.Property(p => p.Fornecedor)                
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)                
                .HasColumnType("varchar(2000)");

            builder.ToTable("Licencas");
        }

    }
}
