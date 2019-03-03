using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Logs");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CustomerId",
                table: "Logs",
                nullable: true);
        }
    }
}
