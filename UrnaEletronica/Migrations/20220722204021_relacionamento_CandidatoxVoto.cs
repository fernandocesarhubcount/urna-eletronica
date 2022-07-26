using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Migrations
{
    public partial class relacionamento_CandidatoxVoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vote_candidate_id",
                table: "vote");

            migrationBuilder.CreateIndex(
                name: "IX_vote_candidate_id",
                table: "vote",
                column: "candidate_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vote_candidate_id",
                table: "vote");

            migrationBuilder.CreateIndex(
                name: "IX_vote_candidate_id",
                table: "vote",
                column: "candidate_id",
                unique: true);
        }
    }
}
