﻿// <auto-generated />
using System;
using Geti.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Geti.Data.Migrations
{
    [DbContext(typeof(GetiDbContext))]
    [Migration("20220226234041_AdicionandoCampoNomeColaborador")]
    partial class AdicionandoCampoNomeColaborador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EquipamentoLicenca", b =>
                {
                    b.Property<Guid>("EquipamentosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LicencasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EquipamentosId", "LicencasId");

                    b.HasIndex("LicencasId");

                    b.ToTable("EquipamentoLicenca");
                });

            modelBuilder.Entity("Geti.Business.Models.Colaborador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Geti.Business.Models.Equipamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColaboradorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAquisicao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NotaFiscal")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Patrimonio")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("StatusEquipamento")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoEquipamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("Geti.Business.Models.Licenca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Software")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Licencas");
                });

            modelBuilder.Entity("EquipamentoLicenca", b =>
                {
                    b.HasOne("Geti.Business.Models.Equipamento", null)
                        .WithMany()
                        .HasForeignKey("EquipamentosId")
                        .IsRequired();

                    b.HasOne("Geti.Business.Models.Licenca", null)
                        .WithMany()
                        .HasForeignKey("LicencasId")
                        .IsRequired();
                });

            modelBuilder.Entity("Geti.Business.Models.Equipamento", b =>
                {
                    b.HasOne("Geti.Business.Models.Colaborador", "Colaborador")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ColaboradorId")
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("Geti.Business.Models.Colaborador", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
