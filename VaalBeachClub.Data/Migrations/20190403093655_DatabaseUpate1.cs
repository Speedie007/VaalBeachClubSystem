using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class DatabaseUpate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatHouses_BoatHouseSizes_BoatHouseSizeID",
                table: "BoatHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureId",
                table: "EntranceCommissionFees");

            migrationBuilder.DropIndex(
                name: "IX_BoatHouses_BoatHouseSizeID",
                table: "BoatHouses");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "BoatHouseSizes");

            migrationBuilder.RenameColumn(
                name: "BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                newName: "BeachClubFeeStructureID");

            migrationBuilder.RenameIndex(
                name: "IX_EntranceCommissionFees_BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                newName: "IX_EntranceCommissionFees_BeachClubFeeStructureID");

            migrationBuilder.AlterColumn<int>(
                name: "BeachClubFeeStructureID",
                table: "EntranceCommissionFees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "BoatHouseSizes",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AddColumn<decimal>(
                name: "Hieght",
                table: "BoatHouseSizes",
                type: "numeric(18, 1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "BoatHouseSizes",
                type: "numeric(18, 1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Width",
                table: "BoatHouseSizes",
                type: "numeric(18, 1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouses_BoatHouseSizeID",
                table: "BoatHouses",
                column: "BoatHouseSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatHouses_BoatHouseSizes",
                table: "BoatHouses",
                column: "BoatHouseSizeID",
                principalTable: "BoatHouseSizes",
                principalColumn: "BoatHouseSizeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureID",
                table: "EntranceCommissionFees",
                column: "BeachClubFeeStructureID",
                principalTable: "BeachClubFeeStructures",
                principalColumn: "BeachClubFeeStructureID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatHouses_BoatHouseSizes",
                table: "BoatHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureID",
                table: "EntranceCommissionFees");

            migrationBuilder.DropIndex(
                name: "IX_BoatHouses_BoatHouseSizeID",
                table: "BoatHouses");

            migrationBuilder.DropColumn(
                name: "Hieght",
                table: "BoatHouseSizes");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "BoatHouseSizes");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "BoatHouseSizes");

            migrationBuilder.RenameColumn(
                name: "BeachClubFeeStructureID",
                table: "EntranceCommissionFees",
                newName: "BeachClubFeeStructureId");

            migrationBuilder.RenameIndex(
                name: "IX_EntranceCommissionFees_BeachClubFeeStructureID",
                table: "EntranceCommissionFees",
                newName: "IX_EntranceCommissionFees_BeachClubFeeStructureId");

            migrationBuilder.AlterColumn<int>(
                name: "BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "BoatHouseSizes",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddColumn<long>(
                name: "Size",
                table: "BoatHouseSizes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouses_BoatHouseSizeID",
                table: "BoatHouses",
                column: "BoatHouseSizeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoatHouses_BoatHouseSizes_BoatHouseSizeID",
                table: "BoatHouses",
                column: "BoatHouseSizeID",
                principalTable: "BoatHouseSizes",
                principalColumn: "BoatHouseSizeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                column: "BeachClubFeeStructureId",
                principalTable: "BeachClubFeeStructures",
                principalColumn: "BeachClubFeeStructureID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
