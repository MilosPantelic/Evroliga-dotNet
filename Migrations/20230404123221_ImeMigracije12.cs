using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evroliga.Migrations
{
    /// <inheritdoc />
    public partial class ImeMigracije12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Shoot",
                table: "State",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shoot",
                table: "State");
        }
    }
}
