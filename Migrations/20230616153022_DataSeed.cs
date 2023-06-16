using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SwimmingStyleAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SwimmingStyles",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "The front crawl or forward crawl, also known as the Australi", "freeStyle", "Crawl" },
                    { 2, null, "Butterfly", "Butterfly" }
                });

            migrationBuilder.InsertData(
                table: "StatsSwimmingStyles",
                columns: new[] { "Id", "Difficulty", "Endurance", "Speed", "SwimmingStyleEntitiesId", "Technique" },
                values: new object[,]
                {
                    { 1, 2, 2, 2, 1, 2 },
                    { 2, 3, 3, 3, 1, 4 },
                    { 3, 4, 4, 4, 2, 4 },
                    { 4, 5, 5, 5, 2, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatsSwimmingStyles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatsSwimmingStyles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatsSwimmingStyles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatsSwimmingStyles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SwimmingStyles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SwimmingStyles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
