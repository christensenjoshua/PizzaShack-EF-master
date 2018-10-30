using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaShack.Data.Migrations
{
    public partial class fixedSidesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sides",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Sides",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
