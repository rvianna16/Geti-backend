using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    Chave = table.Column<string>(type: "varchar(100)", nullable: false),
                    Software = table.Column<string>(type: "varchar(50)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Patrimonio = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoEquipamento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotaFiscal = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoLicenca",
                columns: table => new
                {
                    EquipamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicencasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoLicenca", x => new { x.EquipamentosId, x.LicencasId });
                    table.ForeignKey(
                        name: "FK_EquipamentoLicenca_Equipamentos_EquipamentosId",
                        column: x => x.EquipamentosId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipamentoLicenca_Licencas_LicencasId",
                        column: x => x.LicencasId,
                        principalTable: "Licencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoLicenca_LicencasId",
                table: "EquipamentoLicenca",
                column: "LicencasId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ColaboradorId",
                table: "Equipamentos",
                column: "ColaboradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoLicenca");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Licencas");

            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
