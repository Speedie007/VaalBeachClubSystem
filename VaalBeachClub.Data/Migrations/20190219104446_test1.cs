using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubFeeStructures_EntranceCommissionFees_EntranceCommissionFeeId",
                table: "BeachClubFeeStructures");

            migrationBuilder.DropIndex(
                name: "IX_BeachClubFeeStructures_EntranceCommissionFeeId",
                table: "BeachClubFeeStructures");

            migrationBuilder.DropColumn(
                name: "EntranceCommissionFeeId",
                table: "BeachClubFeeStructures");

            migrationBuilder.AddColumn<int>(
                name: "BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntranceCommissionFees_BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                column: "BeachClubFeeStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureId",
                table: "EntranceCommissionFees",
                column: "BeachClubFeeStructureId",
                principalTable: "BeachClubFeeStructures",
                principalColumn: "BeachClubFeeStructureID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureId",
                table: "EntranceCommissionFees");

            migrationBuilder.DropIndex(
                name: "IX_EntranceCommissionFees_BeachClubFeeStructureId",
                table: "EntranceCommissionFees");

            migrationBuilder.DropColumn(
                name: "BeachClubFeeStructureId",
                table: "EntranceCommissionFees");

            migrationBuilder.AddColumn<int>(
                name: "EntranceCommissionFeeId",
                table: "BeachClubFeeStructures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubFeeStructures_EntranceCommissionFeeId",
                table: "BeachClubFeeStructures",
                column: "EntranceCommissionFeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeachClubFeeStructures_EntranceCommissionFees_EntranceCommissionFeeId",
                table: "BeachClubFeeStructures",
                column: "EntranceCommissionFeeId",
                principalTable: "EntranceCommissionFees",
                principalColumn: "CommissionFeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
