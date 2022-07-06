using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_DOS.Migrations
{
    public partial class DBCadastroCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro_Curso",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCur = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true),
                    Ano = table.Column<string>(nullable: true),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    Aluno = table.Column<string>(nullable: true),
                    CargaHor = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true),
                    CodPro = table.Column<string>(nullable: true),
                    Hora1 = table.Column<string>(nullable: true),
                    Hora2 = table.Column<string>(nullable: true),
                    Valor = table.Column<float>(nullable: false),
                    Classe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro_Curso", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro_Curso");
        }
    }
}
