using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidate",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome_canditato = table.Column<string>(type: "TEXT", nullable: false),
                    nome_vice = table.Column<string>(type: "TEXT", nullable: false),
                    legenda = table.Column<int>(type: "INTEGER", nullable: false),
                    data_registro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    quantidade_votos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    candidate_id = table.Column<int>(type: "INTEGER", nullable: false),
                    data_voto = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vote", x => x.id);
                    table.ForeignKey(
                        name: "FK_vote_candidate_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vote_candidate_id",
                table: "vote",
                column: "candidate_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "candidate");
        }
    }
}
