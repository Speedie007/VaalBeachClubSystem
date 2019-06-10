using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnSiteStorageItem",
                table: "ItemTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ItemTypeHierarchy",
                columns: table => new
                {
                    ItemTypeHierarchyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentID = table.Column<int>(nullable: false),
                    ChildID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeHierarchy", x => x.ItemTypeHierarchyID);
                    table.ForeignKey(
                        name: "FK_ItemTypeHierarchy_ItemTypes",
                        column: x => x.ParentID,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeHierarchy_ParentID",
                table: "ItemTypeHierarchy",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTypeHierarchy");

            migrationBuilder.DropColumn(
                name: "IsOnSiteStorageItem",
                table: "ItemTypes");
        }
    }
}
