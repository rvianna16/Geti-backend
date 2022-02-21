﻿using Geti.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geti.Data.Mappings
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.ToTable("Colaboradores");
        }

    }
}
