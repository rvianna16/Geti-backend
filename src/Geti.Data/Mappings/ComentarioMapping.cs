using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Data.Mappings
{
    public class ComentarioMapping : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(500)");

            builder.ToTable("Comentarios");
        }
    }
}
