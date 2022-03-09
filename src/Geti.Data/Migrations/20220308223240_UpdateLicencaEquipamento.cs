using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class UpdateLicencaEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipamentoLicenca_Equipamentos_EquipamentosId",
                table: "EquipamentoLicenca");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipamentoLicenca_Licencas_LicencasId",
                table: "EquipamentoLicenca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipamentoLicenca",
                table: "EquipamentoLicenca");

            migrationBuilder.RenameColumn(
                name: "LicencasId",
                table: "EquipamentoLicenca",
                newName: "LicencaId");

            migrationBuilder.RenameColumn(
                name: "EquipamentosId",
                table: "EquipamentoLicenca",
                newName: "EquipamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipamentoLicenca_LicencasId",
                table: "EquipamentoLicenca",
                newName: "IX_EquipamentoLicenca_LicencaId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EquipamentoLicenca",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipamentoLicenca",
                table: "EquipamentoLicenca",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoLicenca_EquipamentoId",
                table: "EquipamentoLicenca",
                column: "EquipamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoLicenca_Equipamentos_EquipamentoId",
                table: "EquipamentoLicenca",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoLicenca_Licencas_LicencaId",
                table: "EquipamentoLicenca",
                column: "LicencaId",
                principalTable: "Licencas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipamentoLicenca_Equipamentos_EquipamentoId",
                table: "EquipamentoLicenca");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipamentoLicenca_Licencas_LicencaId",
                table: "EquipamentoLicenca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipamentoLicenca",
                table: "EquipamentoLicenca");

            migrationBuilder.DropIndex(
                name: "IX_EquipamentoLicenca_EquipamentoId",
                table: "EquipamentoLicenca");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EquipamentoLicenca");

            migrationBuilder.RenameColumn(
                name: "LicencaId",
                table: "EquipamentoLicenca",
                newName: "LicencasId");

            migrationBuilder.RenameColumn(
                name: "EquipamentoId",
                table: "EquipamentoLicenca",
                newName: "EquipamentosId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipamentoLicenca_LicencaId",
                table: "EquipamentoLicenca",
                newName: "IX_EquipamentoLicenca_LicencasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipamentoLicenca",
                table: "EquipamentoLicenca",
                columns: new[] { "EquipamentosId", "LicencasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoLicenca_Equipamentos_EquipamentosId",
                table: "EquipamentoLicenca",
                column: "EquipamentosId",
                principalTable: "Equipamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipamentoLicenca_Licencas_LicencasId",
                table: "EquipamentoLicenca",
                column: "LicencasId",
                principalTable: "Licencas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
