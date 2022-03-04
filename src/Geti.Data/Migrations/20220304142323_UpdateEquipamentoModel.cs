using Microsoft.EntityFrameworkCore.Migrations;

namespace Geti.Data.Migrations
{
    public partial class UpdateEquipamentoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Licencas",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Patrimonio",
                table: "Equipamentos",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Equipamentos",
                type: "varchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<string>(
                name: "Armazenamento",
                table: "Equipamentos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "Equipamentos",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Equipamentos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Processador",
                table: "Equipamentos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Colaboradores",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Armazenamento",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "Processador",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Licencas",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Patrimonio",
                table: "Equipamentos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Equipamentos",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4000)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Colaboradores",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
