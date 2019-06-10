using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeProperties_ItemTypes",
                table: "ItemTypeProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeProperties_ItemTypes",
                table: "ItemTypeProperties",
                column: "ItemID",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypeProperties_ItemTypes",
                table: "ItemTypeProperties");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypeProperties_ItemTypes",
                table: "ItemTypeProperties",
                column: "ItemID",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
