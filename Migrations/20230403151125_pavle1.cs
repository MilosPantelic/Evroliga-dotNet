using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evroliga.Migrations
{
    /// <inheritdoc />
    public partial class pavle1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_City_CityId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Team",
                newName: "Cityid");

            migrationBuilder.RenameIndex(
                name: "IX_Team_CityId",
                table: "Team",
                newName: "IX_Team_Cityid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_City_Cityid",
                table: "Team",
                column: "Cityid",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_City_Cityid",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "Cityid",
                table: "Team",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_Cityid",
                table: "Team",
                newName: "IX_Team_CityId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "City",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_City_CityId",
                table: "Team",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
