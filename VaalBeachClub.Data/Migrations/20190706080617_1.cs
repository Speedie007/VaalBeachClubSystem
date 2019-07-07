using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaalBeachClub.Data.Migrations
{
    public partial class _1 : Migration
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
                name: "AffiliatedMemberTypes",
                columns: table => new
                {
                    AffiliatedMemberTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AffiliatedMemberTypeName = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliatedMemberTypes", x => x.AffiliatedMemberTypeID);
                });

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
                name: "BeachClubFiles",
                columns: table => new
                {
                    FileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentType = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    FileName = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    FileExtension = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    FileSize = table.Column<long>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubFiles", x => x.FileID);
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
                name: "BoatHouseRentalStatuses",
                columns: table => new
                {
                    BoatHouseRentalStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RentalStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatHouseRentalStatuses", x => x.BoatHouseRentalStatusID);
                });

            migrationBuilder.CreateTable(
                name: "BoatHouseSizes",
                columns: table => new
                {
                    BoatHouseSizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    Length = table.Column<decimal>(type: "numeric(18, 1)", nullable: false),
                    Width = table.Column<decimal>(type: "numeric(18, 1)", nullable: false),
                    Hieght = table.Column<decimal>(type: "numeric(18, 1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatHouseSizes", x => x.BoatHouseSizeID);
                });

            migrationBuilder.CreateTable(
                name: "CampSite",
                columns: table => new
                {
                    CampSiteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampSiteNumber = table.Column<string>(nullable: true),
                    CampSiteCapacity = table.Column<int>(nullable: false),
                    hasElectricity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampSite", x => x.CampSiteID);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetailTypes",
                columns: table => new
                {
                    ContactDetailTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactDetailTypeValue = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetailTypes", x => x.ContactDetailTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(unicode: false, maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "ItemPropertyDataTypes",
                columns: table => new
                {
                    ItemPropertyDataTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemPropertyDataTypeName = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPropertyDataTypes", x => x.ItemPropertyDataTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Item = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    IsOnSiteStorageItem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EntranceCommissionFee",
                columns: table => new
                {
                    CommissionFeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommisionPercentage = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    IsCurrentRate = table.Column<bool>(nullable: false),
                    DateLastUpdated = table.Column<DateTime>(nullable: false),
                    BeachClubFeeStructureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceCommissionFee", x => x.CommissionFeeID);
                    table.ForeignKey(
                        name: "FK_EntranceCommissionFee_BeachClubFeeStructures_BeachClubFeeStructureID",
                        column: x => x.BeachClubFeeStructureID,
                        principalTable: "BeachClubFeeStructures",
                        principalColumn: "BeachClubFeeStructureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileBlobs",
                columns: table => new
                {
                    FileID = table.Column<int>(nullable: false),
                    BlobData = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileBlobs", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_BeachClubFileBlobs_BeachClubFiles131123",
                        column: x => x.FileID,
                        principalTable: "BeachClubFiles",
                        principalColumn: "FileID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "AffiliatedMembers",
                columns: table => new
                {
                    AffiliatedMemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 75, nullable: true),
                    LastName = table.Column<string>(maxLength: 75, nullable: true),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    AffiliatedMemberTypeID = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliatedMembers", x => x.AffiliatedMemberID);
                    table.ForeignKey(
                        name: "FK_AffiliatedMembers_AffiliatedMemberTypes",
                        column: x => x.AffiliatedMemberTypeID,
                        principalTable: "AffiliatedMemberTypes",
                        principalColumn: "AffiliatedMemberTypeID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogLevelId = table.Column<int>(nullable: false),
                    ShortMessage = table.Column<string>(nullable: true),
                    FullMessage = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
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
                name: "MemberProfileImages",
                columns: table => new
                {
                    FileID = table.Column<int>(nullable: false),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    DateLastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProfileImages", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_MemberProfileImages_BeachClubMembers",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeachClubFileBlobs_BeachClubFiles1",
                        column: x => x.FileID,
                        principalTable: "BeachClubFiles",
                        principalColumn: "FileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberRegistrations",
                columns: table => new
                {
                    MemberRegistrationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateRegistrationCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    HasReadTermsAndConditions = table.Column<bool>(nullable: false),
                    HasBeenProcessed = table.Column<bool>(nullable: false),
                    HasBeenApproved = table.Column<bool>(nullable: false),
                    HasBeenPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRegistrations", x => x.MemberRegistrationID);
                    table.ForeignKey(
                        name: "FK_MemberRegistrations_BeachClubMembers",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_BoatHouses_BoatHouseSizes",
                        column: x => x.BoatHouseSizeID,
                        principalTable: "BoatHouseSizes",
                        principalColumn: "BoatHouseSizeID",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_CampSiteBookings_CampSite_CampSiteID",
                        column: x => x.CampSiteID,
                        principalTable: "CampSite",
                        principalColumn: "CampSiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    ContactDetailTypeID = table.Column<int>(nullable: false),
                    ContactDetailValue = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailID);
                    table.ForeignKey(
                        name: "FK_ContactDetails_BeachClubMembers",
                        column: x => x.BeachClubMemberID,
                        principalTable: "BeachClubMembers",
                        principalColumn: "BeachClubMemberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactDetails_ContactDetailTypes",
                        column: x => x.ContactDetailTypeID,
                        principalTable: "ContactDetailTypes",
                        principalColumn: "ContactDetailTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    IsPrimaryAddress = table.Column<bool>(nullable: false),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    CountryID = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Addresses_Countries",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemProperties",
                columns: table => new
                {
                    ItemPropertyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemPropertyDataTypeID = table.Column<int>(nullable: false),
                    Property = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProperties", x => x.ItemPropertyID);
                    table.ForeignKey(
                        name: "FK_ItemProperties_ItemPropertyDataTypes",
                        column: x => x.ItemPropertyDataTypeID,
                        principalTable: "ItemPropertyDataTypes",
                        principalColumn: "ItemPropertyDataTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeHierarchy",
                columns: table => new
                {
                    ItemTypeHierarchyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentID = table.Column<int>(nullable: false),
                    ChildID = table.Column<int>(nullable: false),
                    OccupiesSameSpaceAsParent = table.Column<bool>(nullable: false),
                    IsOptional = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MemberItems",
                columns: table => new
                {
                    MemberItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberItemParentID = table.Column<int>(nullable: false),
                    BeachClubMemberID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    IsOnSite = table.Column<bool>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_MemberItems_ItemTypes",
                        column: x => x.ItemID,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.Restrict);
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
                    BoatHouseID = table.Column<int>(nullable: false),
                    BoatHouseRentalStatusID = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_BoatHouseRentals_BoatHouseRentalStatuses_BoatHouseRentalStatusID",
                        column: x => x.BoatHouseRentalStatusID,
                        principalTable: "BoatHouseRentalStatuses",
                        principalColumn: "BoatHouseRentalStatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeProperties",
                columns: table => new
                {
                    ItemTypePropertyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: false),
                    ItemPropertyID = table.Column<int>(nullable: false),
                    ItemPropertyRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeProperties", x => x.ItemTypePropertyID);
                    table.ForeignKey(
                        name: "FK_ItemTypeProperties_ItemTypes",
                        column: x => x.ItemID,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTypeProperties_ItemProperties",
                        column: x => x.ItemPropertyID,
                        principalTable: "ItemProperties",
                        principalColumn: "ItemPropertyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberItemProperties",
                columns: table => new
                {
                    MemberItemPropertyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberItemID = table.Column<int>(nullable: false),
                    ItemPropertyID = table.Column<int>(nullable: false),
                    Value = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberItemProperties", x => x.MemberItemPropertyID);
                    table.ForeignKey(
                        name: "FK_MemberItemProperties_ItemProperties_1",
                        column: x => x.ItemPropertyID,
                        principalTable: "ItemProperties",
                        principalColumn: "ItemPropertyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberItemProperties_MemberItems_1",
                        column: x => x.MemberItemID,
                        principalTable: "MemberItems",
                        principalColumn: "MemberItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberItemInStorage",
                columns: table => new
                {
                    MemberItemInStorageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoatHouseRentalID = table.Column<int>(nullable: false),
                    MemberItemID = table.Column<int>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "AffiliatedMemberTypes",
                columns: new[] { "AffiliatedMemberTypeID", "AffiliatedMemberTypeName" },
                values: new object[,]
                {
                    { 6, "Guest" },
                    { 5, "Other_Direct_Relative" },
                    { 4, "Daughter" },
                    { 3, "Son" },
                    { 2, "Husband" },
                    { 1, "Wife" }
                });

            migrationBuilder.InsertData(
                table: "BoatHouseRentalStatuses",
                columns: new[] { "BoatHouseRentalStatusID", "RentalStatus" },
                values: new object[,]
                {
                    { 3, "Active" },
                    { 1, "Reserved" },
                    { 2, "Suspended" }
                });

            migrationBuilder.InsertData(
                table: "BoatHouseSizes",
                columns: new[] { "BoatHouseSizeID", "Cost", "Description", "Hieght", "Length", "Width" },
                values: new object[,]
                {
                    { 1, 14380m, "Boat Size A", 2.5m, 8m, 3m },
                    { 6, 20340m, "Boat Size F", 3.5m, 12m, 3.5m },
                    { 5, 20340m, "Boat Size E", 2.8m, 12m, 3.5m },
                    { 4, 18117m, "Boat Size D", 4m, 10m, 3.5m },
                    { 3, 16392m, "Boat Size C", 3.5m, 9m, 3.5m },
                    { 2, 16392m, "Boat Size B", 2.8m, 9m, 3.5m }
                });

            migrationBuilder.InsertData(
                table: "ContactDetailTypes",
                columns: new[] { "ContactDetailTypeID", "ContactDetailTypeValue" },
                values: new object[,]
                {
                    { 3, "Office Number" },
                    { 2, "Cell Number" },
                    { 1, "Email Address" },
                    { 4, "Home Number" }
                });

            migrationBuilder.InsertData(
                table: "ItemPropertyDataTypes",
                columns: new[] { "ItemPropertyDataTypeID", "ItemPropertyDataTypeName" },
                values: new object[,]
                {
                    { 1, "TEXT" },
                    { 2, "NUMERIC" }
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "ItemTypeID", "IsOnSiteStorageItem", "Item" },
                values: new object[,]
                {
                    { 2, false, "Boat" },
                    { 3, false, "JetSki" },
                    { 4, false, "Vechicle" },
                    { 5, false, "Wake Board Tower" },
                    { 1, false, "Trailer" }
                });

            migrationBuilder.InsertData(
                table: "BoatHouses",
                columns: new[] { "BoatHouseID", "BoatHouseNumber", "BoatHouseSizeID" },
                values: new object[,]
                {
                    { 1, "BH001", 1 },
                    { 2, "BH002", 2 },
                    { 3, "BH003", 3 },
                    { 4, "BH004", 4 },
                    { 5, "BH005", 5 },
                    { 6, "BH006", 6 }
                });

            migrationBuilder.InsertData(
                table: "ItemProperties",
                columns: new[] { "ItemPropertyID", "ItemPropertyDataTypeID", "Property" },
                values: new object[,]
                {
                    { 1, 1, "Colour" },
                    { 2, 1, "Make" },
                    { 3, 1, "Boat Name" },
                    { 6, 1, "Registration Number" },
                    { 7, 1, "Model" },
                    { 8, 1, "Make Of Engine" },
                    { 9, 1, "Width" },
                    { 4, 2, "Length" },
                    { 5, 2, "Height" }
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
                name: "IX_Addresses_BeachClubMemberID",
                table: "Addresses",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryID",
                table: "Addresses",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliatedMembers_AffiliatedMemberTypeID",
                table: "AffiliatedMembers",
                column: "AffiliatedMemberTypeID");

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
                name: "IX_BoatHouseRentals_BoatHouseRentalStatusID",
                table: "BoatHouseRentals",
                column: "BoatHouseRentalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_BoatHouses_BoatHouseSizeID",
                table: "BoatHouses",
                column: "BoatHouseSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_CampSiteBookings_BeachClubMemberID",
                table: "CampSiteBookings",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_CampSiteBookings_CampSiteID",
                table: "CampSiteBookings",
                column: "CampSiteID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_BeachClubMemberID",
                table: "ContactDetails",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactDetailTypeID",
                table: "ContactDetails",
                column: "ContactDetailTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EntranceCommissionFee_BeachClubFeeStructureID",
                table: "EntranceCommissionFee",
                column: "BeachClubFeeStructureID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProperties_ItemPropertyDataTypeID",
                table: "ItemProperties",
                column: "ItemPropertyDataTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeHierarchy_ParentID",
                table: "ItemTypeHierarchy",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeProperties_ItemID",
                table: "ItemTypeProperties",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeProperties_ItemPropertyID",
                table: "ItemTypeProperties",
                column: "ItemPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_MemberId",
                table: "Logs",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemInStorage_BoatHouseRentalID",
                table: "MemberItemInStorage",
                column: "BoatHouseRentalID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemInStorage_MemberItemID",
                table: "MemberItemInStorage",
                column: "MemberItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemProperties_ItemPropertyID",
                table: "MemberItemProperties",
                column: "ItemPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemProperties_MemberItemID",
                table: "MemberItemProperties",
                column: "MemberItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItems_BeachClubMemberID",
                table: "MemberItems",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItems_ItemID",
                table: "MemberItems",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfileImages_BeachClubMemberID",
                table: "MemberProfileImages",
                column: "BeachClubMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRegistrations_BeachClubMemberID",
                table: "MemberRegistrations",
                column: "BeachClubMemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AffiliatedMembers");

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
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "EntranceCommissionFee");

            migrationBuilder.DropTable(
                name: "FileBlobs");

            migrationBuilder.DropTable(
                name: "ItemTypeHierarchy");

            migrationBuilder.DropTable(
                name: "ItemTypeProperties");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MemberItemInStorage");

            migrationBuilder.DropTable(
                name: "MemberItemProperties");

            migrationBuilder.DropTable(
                name: "MemberProfileImages");

            migrationBuilder.DropTable(
                name: "MemberRegistrations");

            migrationBuilder.DropTable(
                name: "ActivityLogTypes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AffiliatedMemberTypes");

            migrationBuilder.DropTable(
                name: "BeachClubRoles");

            migrationBuilder.DropTable(
                name: "CampSite");

            migrationBuilder.DropTable(
                name: "ContactDetailTypes");

            migrationBuilder.DropTable(
                name: "BeachClubFeeStructures");

            migrationBuilder.DropTable(
                name: "BoatHouseRentals");

            migrationBuilder.DropTable(
                name: "ItemProperties");

            migrationBuilder.DropTable(
                name: "MemberItems");

            migrationBuilder.DropTable(
                name: "BeachClubFiles");

            migrationBuilder.DropTable(
                name: "BoatHouses");

            migrationBuilder.DropTable(
                name: "BoatHouseRentalStatuses");

            migrationBuilder.DropTable(
                name: "ItemPropertyDataTypes");

            migrationBuilder.DropTable(
                name: "BeachClubMembers");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "BoatHouseSizes");
        }
    }
}
