using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronica.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Legenda = table.Column<int>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: false),
                    NomeVice = table.Column<string>(nullable: false),
                    DataDeRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.IdCandidato);
                });

            migrationBuilder.CreateTable(
                name: "Votos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidato = table.Column<int>(nullable: true),
                    DataDoVoto = table.Column<DateTime>(nullable: false),
                    VotoEmBranco = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Candidatos_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidatos",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_IdCandidato",
                table: "Votos",
                column: "IdCandidato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votos");

            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
