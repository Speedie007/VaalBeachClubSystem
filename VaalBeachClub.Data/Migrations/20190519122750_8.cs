using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [GetAllItemTypes]
                    
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT ItemTypeID, Item FROM ItemTypes
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
