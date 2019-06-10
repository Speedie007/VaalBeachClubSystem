using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 1,
                column: "Item",
                value: "Trailer");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 2,
                column: "Item",
                value: "Boat");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 3,
                column: "Item",
                value: "JetSki");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 4,
                column: "Item",
                value: "Vechicle");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 5,
                column: "Item",
                value: "Wake Board Tower");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 1,
                column: "Item",
                value: "Car");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 2,
                column: "Item",
                value: "Trailer");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 3,
                column: "Item",
                value: "Boat");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 4,
                column: "Item",
                value: "JetSki");

            migrationBuilder.UpdateData(
                table: "ItemTypes",
                keyColumn: "ItemTypeID",
                keyValue: 5,
                column: "Item",
                value: "Vechicle");

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "ItemTypeID", "Item" },
                values: new object[] { 6, "Wake Board Tower" });
        }
    }
}
