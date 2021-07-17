using Microsoft.EntityFrameworkCore.Migrations;

namespace Ex.Infra.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "Tenant",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Customer",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tenant",
                newName: "Tittle");

            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
