using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evroliga.Migrations
{
    /// <inheritdoc />
    public partial class sada122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameCities",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameCities",
                table: "Team");
        }
    }
}
