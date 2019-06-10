using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Data.StoreProcesdures
{
    public partial class spGetItemTypes : Migration
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
            base.Down(migrationBuilder);
        }
    }
}
