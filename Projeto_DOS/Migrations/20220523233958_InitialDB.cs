using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_DOS.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadalu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NFicha = table.Column<string>(nullable: true),
                    NoCIC = table.Column<string>(nullable: true),
                    CodCuR = table.Column<string>(nullable: true),
                    Turma = table.Column<string>(nullable: true),
                    CodAlu = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true),
                    Fpag = table.Column<string>(nullable: true),
                    Dia = table.Column<string>(nullable: true),
                    Curri = table.Column<string>(nullable: true),
                    Certi = table.Column<string>(nullable: true),
                    Histo = table.Column<string>(nullable: true),
                    CIC = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Crea = table.Column<string>(nullable: true),
                    Contrato = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    EmDia = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Lista = table.Column<string>(nullable: true),
                    Carta = table.Column<string>(nullable: true),
                    DataInc = table.Column<string>(nullable: true),
                    Status1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadalu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadalu");
        }
    }
}
