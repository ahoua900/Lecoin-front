using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecoin.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NOmComplet",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Pseudo_Client",
                table: "Clients",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pseudo_Client",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "NOmComplet",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
