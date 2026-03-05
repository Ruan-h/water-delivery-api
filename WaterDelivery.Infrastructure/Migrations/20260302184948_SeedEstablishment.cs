using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterDelivery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedEstablishment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Establishments",
                columns: new[] { "Id", "IsOpen", "Name" },
                values: new object[] { 1, true, "Water Delivery" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Establishments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
