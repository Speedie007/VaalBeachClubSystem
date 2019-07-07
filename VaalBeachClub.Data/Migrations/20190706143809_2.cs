using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AffiliatedMemberTypes",
                keyColumn: "AffiliatedMemberTypeID",
                keyValue: 5,
                column: "AffiliatedMemberTypeName",
                value: "Other Direct Relative");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AffiliatedMemberTypes",
                keyColumn: "AffiliatedMemberTypeID",
                keyValue: 5,
                column: "AffiliatedMemberTypeName",
                value: "Other_Direct_Relative");
        }
    }
}
