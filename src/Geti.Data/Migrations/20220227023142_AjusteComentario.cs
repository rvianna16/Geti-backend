using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class AjusteComentario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Colaboradores_ColaboradorId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_ColaboradorId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Comentarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ColaboradorId",
                table: "Comentarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ColaboradorId",
                table: "Comentarios",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Colaboradores_ColaboradorId",
                table: "Comentarios",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
