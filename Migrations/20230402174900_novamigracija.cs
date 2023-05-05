using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evroliga.Migrations
{
    /// <inheritdoc />
    public partial class novamigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NuberOfWins",
                table: "Team");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingNumber",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWins",
                table: "Team",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfWins",
                table: "Team");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingNumber",
                table: "Team",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NuberOfWins",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
