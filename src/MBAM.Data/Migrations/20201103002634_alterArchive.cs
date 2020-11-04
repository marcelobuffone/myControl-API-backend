using Microsoft.EntityFrameworkCore.Migrations;

namespace MBAM.Data.Migrations
{
    public partial class alterArchive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Archives");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Archives",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Archives",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Archives",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
