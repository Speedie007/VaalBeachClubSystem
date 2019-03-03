using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class CurrentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeachClubFeeStructures",
                columns: table => new
                {
                    BeachClubFeeStructureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberEntranceFee = table.Column<decimal>(type: "Money", nullable: false),
                    NonMemberEntranceFee = table.Column<decimal>(type: "Money", nullable: false),
                    NonMemberVehicleEntranceFee = table.Column<decimal>(type: "Money", nullable: false),
                    NonMemberBoatEntranceFee = table.Column<decimal>(type: "Money", nullable: false),
                    NonMemberJetSkiEntranceFee = table.Column<decimal>(type: "Money", nullable: false),
                    CampSitePerNight = table.Column<decimal>(type: "Money", nullable: false),
                    CampSitePerPersonForMembers = table.Column<decimal>(type: "Money", nullable: false),
                    CampSitePerPersonForNonMembers = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubFeeStructures", x => x.BeachClubFeeStructureID);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubMembers",
                columns: table => new
                {
                    BeachClubMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubMembers", x => x.BeachClubMemberID);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubRoles",
                columns: table => new
                {
                    BeachClubRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubRoles", x => x.BeachClubRoleID);
                });

            migrationBuilder.CreateTable(
                name: "BoatHouseSizes",
                columns: table => new
                {
                    BoatHouseSizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<long>(nullable: false),
                    Cost = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatHouseSizes", x => x.BoatHouseSizeID);
                });

            migrationBuilder.CreateTable(
                name: "CampSites",
                columns: table => new
                {
                    CampSiteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampSiteNumber = table.Column<string>(nullable: true),
                    hasElectricity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampSites", x => x.CampSiteID);
                });

            migrationBuilder.CreateTable(
                name: "EntranceCommissionFees",
                columns: table => new
                {
                    CommissionFeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommisionPercentage = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    IsCurrentRate = table.Column<bool>(nullable: false),
                    DateLastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceCommissionFees", x => x.CommissionFeeID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    AddressType = table.Column<int>(nullable: false),
                    ComplexName = table.Column<string>(nullable: true),
                    ComplexUnitNumber = table.Column<string>(nullable: true),
                    POBoxNumber = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffiliatedMembers",
                columns: table => new
                {
                    AffiliatedMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 75, nullable: true),
                    LastName = table.Column<string>(maxLength: 75, nullable: true),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    MemberAffiliation = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliatedMembers", x => x.AffiliatedMemberID);
                    table.ForeignKey(
                        name: "FK_AffiliatedMembers_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubMemberClaims",
                columns: table => new
                {
                    BeachClubMemberClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubMemberClaims", x => x.BeachClubMemberClaimID);
                    table.ForeignKey(
                        name: "FK_BeachClubMemberClaims_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubMemberLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    BeachClubMemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubMemberLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_BeachClubMemberLogins_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubMemberTokens",
                columns: table => new
                {
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubMemberTokens", x => new { x.BeachClubMemberID, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_BeachClubMemberTokens_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberItems",
                columns: table => new
                {
                    MemberItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    StorageItemType = table.Column<int>(nullable: false),
                    MemberItemType = table.Column<int>(nullable: false),
                    BoatModel = table.Column<string>(nullable: true),
                    BoatMake = table.Column<string>(nullable: true),
                    BoatRegistration = table.Column<string>(nullable: true),
                    JetSkiModel = table.Column<string>(nullable: true),
                    JetSkiMake = table.Column<string>(nullable: true),
                    JetSkiRegistration = table.Column<string>(nullable: true),
                    MotorHome_JetSkiModel = table.Column<string>(nullable: true),
                    MotorHome_JetSkiMake = table.Column<string>(nullable: true),
                    MotorHome_JetSkiRegistration = table.Column<string>(nullable: true),
                    TrailerRegistration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberItems", x => x.MemberItemID);
                    table.ForeignKey(
                        name: "FK_MemberItems_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubMemberRoles",
                columns: table => new
                {
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    BeachClubRoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubMemberRoles", x => new { x.BeachClubMemberID, x.BeachClubRoleID });
                    table.ForeignKey(
                        name: "FK_BeachClubMemberRoles_BeachClubRoles_BeachClubRoleID",
                        column: x => x.BeachClubRoleID,
                        principalTable: "BeachClubRoles",
                        principalColumn: "BeachClubRoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeachClubMemberRoles_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubRoleClaims",
                columns: table => new
                {
                    BeachClubRoleClaimID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeachClubRoleID = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubRoleClaims", x => x.BeachClubRoleClaimID);
                    table.ForeignKey(
                        name: "FK_BeachClubRoleClaims_BeachClubRoles_BeachClubRoleID",
                        column: x => x.BeachClubRoleID,
                        principalTable: "BeachClubRoles",
                        principalColumn: "BeachClubRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatHouseCommissionFees",
                columns: table => new
                {
                    CommissionFeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommisionPercentage = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    IsCurrentRate = table.Column<bool>(nullable: false),
                    DateLastUpdated = table.Column<DateTime>(nullable: false),
                    BoatHouseSizeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatHouseCommissionFees", x => x.CommissionFeeID);
                    table.ForeignKey(
                        name: "FK_BoatHouseCommissionFees_BoatHouseSizes_BoatHouseSizeID",
                        column: x => x.BoatHouseSizeID,
                        principalTable: "BoatHouseSizes",
                        principalColumn: "BoatHouseSizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatHouses",
                columns: table => new
                {
                    BoatHouseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoatHouseNumber = table.Column<string>(maxLength: 250, nullable: true),
                    BoatHouseSizeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatHouses", x => x.BoatHouseID);
                    table.ForeignKey(
                        name: "FK_BoatHouses_BoatHouseSizes_BoatHouseSizeID",
                        column: x => x.BoatHouseSizeID,
                        principalTable: "BoatHouseSizes",
                        principalColumn: "BoatHouseSizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampSiteBookings",
                columns: table => new
                {
                    CampSiteBookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    CampSiteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampSiteBookings", x => x.CampSiteBookingID);
                    table.ForeignKey(
                        name: "FK_CampSiteBookings_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampSiteBookings_CampSites_CampSiteID",
                        column: x => x.CampSiteID,
                        principalTable: "CampSites",
                        principalColumn: "CampSiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatHouseRentals",
                columns: table => new
                {
                    BoatHouseRentalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    HasBeenPaid = table.Column<bool>(nullable: false),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    BoatHouseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatHouseRentals", x => x.BoatHouseRentalID);
                    table.ForeignKey(
                        name: "FK_BoatHouseRentals_BeachClubMembers_BeachClubMemberID",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatHouseRentals_BoatHouses_BoatHouseID",
                        column: x => x.BoatHouseID,
                        principalTable: "BoatHouses",
                        principalColumn: "BoatHouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberItemInStorage",
                columns: table => new
                {
                    MemberItemInStorageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    item = table.Column<string>(nullable: true),
                    BoatHouseRentalID = table.Column<int>(nullable: true),
                    MemberItemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberItemInStorage", x => x.MemberItemInStorageID);
                    table.ForeignKey(
                        name: "FK_MemberItemInStorage_BoatHouseRentals_BoatHouseRentalID",
                        column: x => x.BoatHouseRentalID,
                        principalTable: "BoatHouseRentals",
                        principalColumn: "BoatHouseRentalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberItemInStorage_MemberItems_MemberItemID",
                        column: x => x.MemberItemID,
                        principalTable: "MemberItems",
                        principalColumn: "MemberItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BeachClubMemberID",
                table: "Addresses",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliatedMembers_BeachClubMemberID",
                table: "AffiliatedMembers",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubMemberClaims_BeachClubMemberID",
                table: "BeachClubMemberClaims",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubMemberLogins_BeachClubMemberID",
                table: "BeachClubMemberLogins",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubMemberRoles_BeachClubRoleID",
                table: "BeachClubMemberRoles",
                column: "BeachClubRoleID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "BeachClubMembers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "BeachClubMembers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubRoleClaims_BeachClubRoleID",
                table: "BeachClubRoleClaims",
                column: "BeachClubRoleID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "BeachClubRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouseCommissionFees_BoatHouseSizeID",
                table: "BoatHouseCommissionFees",
                column: "BoatHouseSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouseRentals_BeachClubMemberID",
                table: "BoatHouseRentals",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouseRentals_BoatHouseID",
                table: "BoatHouseRentals",
                column: "BoatHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouses_BoatHouseSizeID",
                table: "BoatHouses",
                column: "BoatHouseSizeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampSiteBookings_BeachClubMemberID",
                table: "CampSiteBookings",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_CampSiteBookings_CampSiteID",
                table: "CampSiteBookings",
                column: "CampSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemInStorage_BoatHouseRentalID",
                table: "MemberItemInStorage",
                column: "BoatHouseRentalID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemInStorage_MemberItemID",
                table: "MemberItemInStorage",
                column: "MemberItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItems_BeachClubMemberID",
                table: "MemberItems",
                column: "BeachClubMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AffiliatedMembers");

            migrationBuilder.DropTable(
                name: "BeachClubFeeStructures");

            migrationBuilder.DropTable(
                name: "BeachClubMemberClaims");

            migrationBuilder.DropTable(
                name: "BeachClubMemberLogins");

            migrationBuilder.DropTable(
                name: "BeachClubMemberRoles");

            migrationBuilder.DropTable(
                name: "BeachClubMemberTokens");

            migrationBuilder.DropTable(
                name: "BeachClubRoleClaims");

            migrationBuilder.DropTable(
                name: "BoatHouseCommissionFees");

            migrationBuilder.DropTable(
                name: "CampSiteBookings");

            migrationBuilder.DropTable(
                name: "EntranceCommissionFees");

            migrationBuilder.DropTable(
                name: "MemberItemInStorage");

            migrationBuilder.DropTable(
                name: "BeachClubRoles");

            migrationBuilder.DropTable(
                name: "CampSites");

            migrationBuilder.DropTable(
                name: "BoatHouseRentals");

            migrationBuilder.DropTable(
                name: "MemberItems");

            migrationBuilder.DropTable(
                name: "BoatHouses");

            migrationBuilder.DropTable(
                name: "BeachClubMembers");

            migrationBuilder.DropTable(
                name: "BoatHouseSizes");
        }
    }
}
