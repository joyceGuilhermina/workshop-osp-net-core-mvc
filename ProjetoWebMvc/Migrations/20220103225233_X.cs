using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebMvc.Migrations
{
    public partial class X : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "salesRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "salesRecords",
                nullable: false,
                defaultValue: 0);
        }
    }
}
