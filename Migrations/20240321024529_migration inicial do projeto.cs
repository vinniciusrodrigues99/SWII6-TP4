using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vrumvrum.Migrations
{
    public partial class migrationinicialdoprojeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    id_campeonato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.id_campeonato);
                });

            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_corrida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voltas = table.Column<int>(type: "int", nullable: false),
                    tamanho_circuito = table.Column<double>(type: "float", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Corridas_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "id_campeonato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campeonatoid_campeonato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipes_Campeonatos_Campeonatoid_campeonato",
                        column: x => x.Campeonatoid_campeonato,
                        principalTable: "Campeonatos",
                        principalColumn: "id_campeonato");
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    Corridaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pilotos_Corridas_Corridaid",
                        column: x => x.Corridaid,
                        principalTable: "Corridas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Pilotos_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_CampeonatoId",
                table: "Corridas",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_Campeonatoid_campeonato",
                table: "Equipes",
                column: "Campeonatoid_campeonato");

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_Corridaid",
                table: "Pilotos",
                column: "Corridaid");

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_EquipeId",
                table: "Pilotos",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Campeonatos");
        }
    }
}
