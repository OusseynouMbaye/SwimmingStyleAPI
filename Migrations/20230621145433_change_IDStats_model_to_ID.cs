using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwimmingStyleAPI.Migrations
{
    /// <inheritdoc />
    public partial class change_IDStats_model_to_ID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SwimmingStyles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "The butterfly (colloquially shortened to fly) is a swimming stroke swum on the chest, with both arms moving symmetrically, accompanied by the butterfly kick (also known as the dolphin kick).");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SwimmingStyles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);
        }
    }
}
