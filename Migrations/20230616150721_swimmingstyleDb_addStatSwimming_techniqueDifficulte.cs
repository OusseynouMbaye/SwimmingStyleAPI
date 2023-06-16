using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwimmingStyleAPI.Migrations
{
    /// <inheritdoc />
    public partial class swimmingstyleDb_addStatSwimming_techniqueDifficulte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "StatsSwimmingStyles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Technique",
                table: "StatsSwimmingStyles",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "StatsSwimmingStyles");

            migrationBuilder.DropColumn(
                name: "Technique",
                table: "StatsSwimmingStyles");
        }
    }
}
