using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaAPI.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Candidate",
                newName: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Candidate",
                newName: "Id");
        }
    }
}
