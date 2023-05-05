using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evroliga.Migrations
{
    /// <inheritdoc />
    public partial class ime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Team_CityId",
                table: "Team",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_City_CityId",
                table: "Team",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_City_CityId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Team_CityId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Team");
        }
    }
}
