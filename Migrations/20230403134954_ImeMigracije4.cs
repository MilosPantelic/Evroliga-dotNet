using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evroliga.Migrations
{
    /// <inheritdoc />
    public partial class ImeMigracije4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Team_CityId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Team");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
