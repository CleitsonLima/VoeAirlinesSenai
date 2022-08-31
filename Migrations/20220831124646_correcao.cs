using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoeAirlinesSenai.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piloto_Aeronaves_AeronaveId",
                table: "Piloto");

            migrationBuilder.DropIndex(
                name: "IX_Piloto_AeronaveId",
                table: "Piloto");

            migrationBuilder.DropColumn(
                name: "AeronaveId",
                table: "Piloto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AeronaveId",
                table: "Piloto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Piloto_AeronaveId",
                table: "Piloto",
                column: "AeronaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piloto_Aeronaves_AeronaveId",
                table: "Piloto",
                column: "AeronaveId",
                principalTable: "Aeronaves",
                principalColumn: "Id");
        }
    }
}
