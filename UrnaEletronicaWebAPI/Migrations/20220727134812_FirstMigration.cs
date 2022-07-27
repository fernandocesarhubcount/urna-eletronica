using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrnaEletronicaWebAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Legenda = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    NomeVice = table.Column<string>(nullable: true),
                    DataRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Legenda);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LegendaCandidato = table.Column<int>(nullable: true),
                    DataVoto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Legenda", "DataRegistro", "Nome", "NomeVice" },
                values: new object[] { 10, new DateTime(2022, 7, 27, 10, 48, 11, 925, DateTimeKind.Local).AddTicks(944), "Leonardo Macedo", "Felipe Cardoso" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Legenda", "DataRegistro", "Nome", "NomeVice" },
                values: new object[] { 15, new DateTime(2022, 7, 27, 10, 48, 11, 926, DateTimeKind.Local).AddTicks(2999), "Paula Machado", "Maria Souza" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Legenda", "DataRegistro", "Nome", "NomeVice" },
                values: new object[] { 19, new DateTime(2022, 7, 27, 10, 48, 11, 926, DateTimeKind.Local).AddTicks(3018), "Diego Oliveira", "Arnildo Silva" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Legenda", "DataRegistro", "Nome", "NomeVice" },
                values: new object[] { 18, new DateTime(2022, 7, 27, 10, 48, 11, 926, DateTimeKind.Local).AddTicks(3023), "Marcia Fernandes", "Camila Ferreira" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Legenda", "DataRegistro", "Nome", "NomeVice" },
                values: new object[] { 32, new DateTime(2022, 7, 27, 10, 48, 11, 926, DateTimeKind.Local).AddTicks(3023), "João Campos", "César Oliveira" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Legenda", "DataRegistro", "Nome", "NomeVice" },
                values: new object[] { 45, new DateTime(2022, 7, 27, 10, 48, 11, 926, DateTimeKind.Local).AddTicks(3032), "Fernanda Pinheiro", "Maurício Mendes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Votes");
        }
    }
}
