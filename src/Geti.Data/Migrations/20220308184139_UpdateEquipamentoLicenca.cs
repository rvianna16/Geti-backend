using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class UpdateEquipamentoLicenca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Disponivel",
                table: "Licencas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Licencas");
        }
    }
}
