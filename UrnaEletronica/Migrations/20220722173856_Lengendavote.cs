using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Migrations
{
    public partial class Lengendavote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "legenda_codigo",
                table: "vote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "legenda_codigo",
                table: "vote");
        }
    }
}
