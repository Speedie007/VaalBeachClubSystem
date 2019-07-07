using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AffiliatedMemberTypes",
                keyColumn: "AffiliatedMemberTypeID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AffiliatedMemberTypes",
                keyColumn: "AffiliatedMemberTypeID",
                keyValue: 5,
                column: "AffiliatedMemberTypeName",
                value: "Guest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AffiliatedMemberTypes",
                keyColumn: "AffiliatedMemberTypeID",
                keyValue: 5,
                column: "AffiliatedMemberTypeName",
                value: "Other Direct Relative");

            migrationBuilder.InsertData(
                table: "AffiliatedMemberTypes",
                columns: new[] { "AffiliatedMemberTypeID", "AffiliatedMemberTypeName" },
                values: new object[] { 6, "Guest" });
        }
    }
}
