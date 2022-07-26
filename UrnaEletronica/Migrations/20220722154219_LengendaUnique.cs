using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Migrations
{
    public partial class LengendaUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_candidate_legenda",
                table: "candidate",
                column: "legenda",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_candidate_legenda",
                table: "candidate");
        }
    }
}
