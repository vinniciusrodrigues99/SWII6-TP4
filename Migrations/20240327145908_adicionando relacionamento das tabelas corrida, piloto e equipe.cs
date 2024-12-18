using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vrumvrum.Migrations
{
    public partial class adicionandorelacionamentodastabelascorridapilotoeequipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Campeonatos_CampeonatoId",
                table: "Corridas");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Campeonatos_CampeonatoId",
                table: "Corridas",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "id_campeonato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Corridas_Campeonatos_CampeonatoId",
                table: "Corridas");

            migrationBuilder.AddForeignKey(
                name: "FK_Corridas_Campeonatos_CampeonatoId",
                table: "Corridas",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "id_campeonato",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
