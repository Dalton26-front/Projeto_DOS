using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_DOS.Migrations
{
    public partial class DBCodCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codcur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODCURSO = table.Column<string>(nullable: true),
                    TURMA = table.Column<string>(nullable: true),
                    LISTA = table.Column<string>(nullable: true),
                    DATAMOV = table.Column<DateTime>(nullable: false),
                    DISCIPLINA = table.Column<string>(nullable: true),
                    SUBDIS = table.Column<string>(nullable: true),
                    PROFESSOR = table.Column<string>(nullable: true),
                    CODDIS = table.Column<string>(nullable: true),
                    CODPRO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codcur", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Codcur");
        }
    }
}
