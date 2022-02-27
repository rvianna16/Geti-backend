using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class AddCampoComentarioFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Colaboradores_ColaboradorId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Equipamentos_EquipamentoId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "Comentarios");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_EquipamentoId",
                table: "Comentarios",
                newName: "IX_Comentarios_EquipamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_ColaboradorId",
                table: "Comentarios",
                newName: "IX_Comentarios_ColaboradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Colaboradores_ColaboradorId",
                table: "Comentarios",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Equipamentos_EquipamentoId",
                table: "Comentarios",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Colaboradores_ColaboradorId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Equipamentos_EquipamentoId",
                table: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Comentario");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_EquipamentoId",
                table: "Comentario",
                newName: "IX_Comentario_EquipamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_ColaboradorId",
                table: "Comentario",
                newName: "IX_Comentario_ColaboradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Colaboradores_ColaboradorId",
                table: "Comentario",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Equipamentos_EquipamentoId",
                table: "Comentario",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
