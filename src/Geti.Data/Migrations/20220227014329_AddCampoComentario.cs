using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class AddCampoComentario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Equipamentos");

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataComentario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentario_Equipamentos_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ColaboradorId",
                table: "Comentario",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_EquipamentoId",
                table: "Comentario",
                column: "EquipamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
