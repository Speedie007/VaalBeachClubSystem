using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemProperties",
                columns: new[] { "ItemPropertyID", "ItemPropertyDataTypeID", "Property" },
                values: new object[] { 9, 1, "Width" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemProperties",
                keyColumn: "ItemPropertyID",
                keyValue: 9);
        }
    }
}
