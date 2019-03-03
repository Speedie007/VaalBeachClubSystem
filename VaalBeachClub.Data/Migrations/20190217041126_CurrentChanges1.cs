using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class CurrentChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SystemKeyword = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogLevelId = table.Column<int>(nullable: false),
                    ShortMessage = table.Column<string>(nullable: true),
                    FullMessage = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    PageUrl = table.Column<string>(nullable: true),
                    ReferrerUrl = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    LogLevel = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_BeachClubMembers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityLogTypeId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    BeachClubMemberId = table.Column<int>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_ActivityLogTypes_ActivityLogTypeId",
                        column: x => x.ActivityLogTypeId,
                        principalTable: "ActivityLogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_BeachClubMembers_BeachClubMemberId",
                        column: x => x.BeachClubMemberId,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ActivityLogTypeId",
                table: "ActivityLogs",
                column: "ActivityLogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_BeachClubMemberId",
                table: "ActivityLogs",
                column: "BeachClubMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_MemberId",
                table: "Logs",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ActivityLogTypes");
        }
    }
}
