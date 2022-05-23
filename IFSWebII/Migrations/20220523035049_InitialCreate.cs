using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IFSWebII.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dificuldade = table.Column<double>(type: "float", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: true),
                    HoraAula = table.Column<int>(type: "int", nullable: true),
                    HoraRelogio = table.Column<int>(type: "int", nullable: true),
                    QtdTeorica = table.Column<int>(type: "int", nullable: true),
                    QtdPratica = table.Column<int>(type: "int", nullable: true),
                    Ementa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prerequisitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDisciplina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomePrerequisito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: true),
                    NecessariaPara = table.Column<int>(type: "int", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prerequisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prerequisitos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisitos_DisciplinaId",
                table: "Prerequisitos",
                column: "DisciplinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prerequisitos");

            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}
