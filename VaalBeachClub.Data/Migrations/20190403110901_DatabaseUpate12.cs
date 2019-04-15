using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class DatabaseUpate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampSiteBookings_CampSites_CampSiteID",
                table: "CampSiteBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureID",
                table: "EntranceCommissionFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntranceCommissionFees",
                table: "EntranceCommissionFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampSites",
                table: "CampSites");

            migrationBuilder.DropColumn(
                name: "BoatMake",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "BoatModel",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "BoatRegistration",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "JetSkiMake",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "JetSkiModel",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "JetSkiRegistration",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "MemberItemType",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "MotorHome_JetSkiMake",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "MotorHome_JetSkiModel",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "MotorHome_JetSkiRegistration",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "TrailerRegistration",
                table: "MemberItems");

            migrationBuilder.DropColumn(
                name: "item",
                table: "MemberItemInStorage");

            migrationBuilder.RenameTable(
                name: "EntranceCommissionFees",
                newName: "EntranceCommissionFee");

            migrationBuilder.RenameTable(
                name: "CampSites",
                newName: "CampSite");

            migrationBuilder.RenameColumn(
                name: "StorageItemType",
                table: "MemberItems",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_EntranceCommissionFees_BeachClubFeeStructureID",
                table: "EntranceCommissionFee",
                newName: "IX_EntranceCommissionFee_BeachClubFeeStructureID");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSite",
                table: "MemberItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "MemberItemID",
                table: "MemberItemInStorage",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BoatHouseRentalID",
                table: "MemberItemInStorage",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntranceCommissionFee",
                table: "EntranceCommissionFee",
                column: "CommissionFeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampSite",
                table: "CampSite",
                column: "CampSiteID");

            migrationBuilder.CreateTable(
                name: "ItemProperties",
                columns: table => new
                {
                    ItemPropertyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Property = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberItemProperties", x => x.ItemPropertyID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Item = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeProperties",
                columns: table => new
                {
                    ItemTypePropertyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: false),
                    ItemPropertyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeProperties", x => x.ItemTypePropertyID);
                    table.ForeignKey(
                        name: "FK_ItemTypeProperties_ItemTypes",
                        column: x => x.ItemID,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTypeProperties_ItemProperties",
                        column: x => x.ItemPropertyID,
                        principalTable: "ItemProperties",
                        principalColumn: "ItemPropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberItems_ItemID",
                table: "MemberItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeProperties_ItemID",
                table: "ItemTypeProperties",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeProperties_ItemPropertyID",
                table: "ItemTypeProperties",
                column: "ItemPropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_CampSiteBookings_CampSite_CampSiteID",
                table: "CampSiteBookings",
                column: "CampSiteID",
                principalTable: "CampSite",
                principalColumn: "CampSiteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceCommissionFee_BeachClubFeeStructures_BeachClubFeeStructureID",
                table: "EntranceCommissionFee",
                column: "BeachClubFeeStructureID",
                principalTable: "BeachClubFeeStructures",
                principalColumn: "BeachClubFeeStructureID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberItems_ItemTypes",
                table: "MemberItems",
                column: "ItemID",
                principalTable: "ItemTypes",
                principalColumn: "ItemTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampSiteBookings_CampSite_CampSiteID",
                table: "CampSiteBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceCommissionFee_BeachClubFeeStructures_BeachClubFeeStructureID",
                table: "EntranceCommissionFee");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberItems_ItemTypes",
                table: "MemberItems");

            migrationBuilder.DropTable(
                name: "ItemTypeProperties");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "ItemProperties");

            migrationBuilder.DropIndex(
                name: "IX_MemberItems_ItemID",
                table: "MemberItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntranceCommissionFee",
                table: "EntranceCommissionFee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampSite",
                table: "CampSite");

            migrationBuilder.DropColumn(
                name: "IsOnSite",
                table: "MemberItems");

            migrationBuilder.RenameTable(
                name: "EntranceCommissionFee",
                newName: "EntranceCommissionFees");

            migrationBuilder.RenameTable(
                name: "CampSite",
                newName: "CampSites");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "MemberItems",
                newName: "StorageItemType");

            migrationBuilder.RenameIndex(
                name: "IX_EntranceCommissionFee_BeachClubFeeStructureID",
                table: "EntranceCommissionFees",
                newName: "IX_EntranceCommissionFees_BeachClubFeeStructureID");

            migrationBuilder.AddColumn<string>(
                name: "BoatMake",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoatModel",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoatRegistration",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JetSkiMake",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JetSkiModel",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JetSkiRegistration",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberItemType",
                table: "MemberItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MotorHome_JetSkiMake",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorHome_JetSkiModel",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotorHome_JetSkiRegistration",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerRegistration",
                table: "MemberItems",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MemberItemID",
                table: "MemberItemInStorage",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BoatHouseRentalID",
                table: "MemberItemInStorage",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "item",
                table: "MemberItemInStorage",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntranceCommissionFees",
                table: "EntranceCommissionFees",
                column: "CommissionFeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampSites",
                table: "CampSites",
                column: "CampSiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_CampSiteBookings_CampSites_CampSiteID",
                table: "CampSiteBookings",
                column: "CampSiteID",
                principalTable: "CampSites",
                principalColumn: "CampSiteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureID",
                table: "EntranceCommissionFees",
                column: "BeachClubFeeStructureID",
                principalTable: "BeachClubFeeStructures",
                principalColumn: "BeachClubFeeStructureID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
