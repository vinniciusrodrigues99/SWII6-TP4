using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vrumvrum.Migrations
{
    public partial class relacionamentodecampeonatoparacorridaeequipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Campeonatos_Campeonatoid_campeonato",
                table: "Equipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pilotos_Corridas_Corridaid",
                table: "Pilotos");

            migrationBuilder.DropIndex(
                name: "IX_Pilotos_Corridaid",
                table: "Pilotos");

            migrationBuilder.DropColumn(
                name: "Corridaid",
                table: "Pilotos");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pilotos",
                newName: "id_piloto");

            migrationBuilder.RenameColumn(
                name: "Campeonatoid_campeonato",
                table: "Equipes",
                newName: "CampeonatoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Equipes",
                newName: "id_equipe");

            migrationBuilder.RenameIndex(
                name: "IX_Equipes_Campeonatoid_campeonato",
                table: "Equipes",
                newName: "IX_Equipes_CampeonatoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Corridas",
                newName: "id_corrida");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Campeonatos_CampeonatoId",
                table: "Equipes",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "id_campeonato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Campeonatos_CampeonatoId",
                table: "Equipes");

            migrationBuilder.RenameColumn(
                name: "id_piloto",
                table: "Pilotos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CampeonatoId",
                table: "Equipes",
                newName: "Campeonatoid_campeonato");

            migrationBuilder.RenameColumn(
                name: "id_equipe",
                table: "Equipes",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Equipes_CampeonatoId",
                table: "Equipes",
                newName: "IX_Equipes_Campeonatoid_campeonato");

            migrationBuilder.RenameColumn(
                name: "id_corrida",
                table: "Corridas",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Corridaid",
                table: "Pilotos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_Corridaid",
                table: "Pilotos",
                column: "Corridaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Campeonatos_Campeonatoid_campeonato",
                table: "Equipes",
                column: "Campeonatoid_campeonato",
                principalTable: "Campeonatos",
                principalColumn: "id_campeonato");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilotos_Corridas_Corridaid",
                table: "Pilotos",
                column: "Corridaid",
                principalTable: "Corridas",
                principalColumn: "id");
        }
    }
}
