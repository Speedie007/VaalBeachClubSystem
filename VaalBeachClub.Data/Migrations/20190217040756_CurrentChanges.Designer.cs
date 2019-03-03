﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaalBeachClub.Data;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190217040756_CurrentChanges")]
    partial class CurrentChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Addresses.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressType");

                    b.Property<string>("AreaCode");

                    b.Property<int>("BeachClubMemberID")
                        .HasColumnName("BeachClubMemberID");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Suburb");

                    b.HasKey("Id");

                    b.HasIndex("BeachClubMemberID");

                    b.ToTable("Addresses");

                    b.HasDiscriminator<int>("AddressType");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.BoatHouses.BoatHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BoatHouseID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoatHouseNumber")
                        .HasColumnName("BoatHouseNumber")
                        .HasMaxLength(250);

                    b.Property<int>("BoatHouseSizeID");

                    b.HasKey("Id");

                    b.HasIndex("BoatHouseSizeID")
                        .IsUnique();

                    b.ToTable("BoatHouses");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.BoatHouses.BoatHouseSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BoatHouseSizeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("Money");

                    b.Property<long>("Size");

                    b.HasKey("Id");

                    b.ToTable("BoatHouseSizes");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Bookings.CampSiteBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CampSiteBookingID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeachClubMemberID");

                    b.Property<int>("CampSiteID");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("Id");

                    b.HasIndex("BeachClubMemberID");

                    b.HasIndex("CampSiteID");

                    b.ToTable("CampSiteBookings");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.CampSites.CampSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CampSiteID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CampSiteNumber");

                    b.Property<bool>("hasElectricity");

                    b.HasKey("Id");

                    b.ToTable("CampSites");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Fees.BeachClubFeeStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BeachClubFeeStructureID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CampSitePerNight")
                        .HasColumnType("Money");

                    b.Property<decimal>("CampSitePerPersonForMembers")
                        .HasColumnType("Money");

                    b.Property<decimal>("CampSitePerPersonForNonMembers")
                        .HasColumnType("Money");

                    b.Property<decimal>("MemberEntranceFee")
                        .HasColumnType("Money");

                    b.Property<decimal>("NonMemberBoatEntranceFee")
                        .HasColumnType("Money");

                    b.Property<decimal>("NonMemberEntranceFee")
                        .HasColumnType("Money");

                    b.Property<decimal>("NonMemberJetSkiEntranceFee")
                        .HasColumnType("Money");

                    b.Property<decimal>("NonMemberVehicleEntranceFee")
                        .HasColumnType("Money");

                    b.HasKey("Id");

                    b.ToTable("BeachClubFeeStructures");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Fees.BoatHouseCommissionFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CommissionFeeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoatHouseSizeID");

                    b.Property<decimal>("CommisionPercentage")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<DateTime>("DateLastUpdated");

                    b.Property<bool>("IsCurrentRate");

                    b.HasKey("Id");

                    b.HasIndex("BoatHouseSizeID");

                    b.ToTable("BoatHouseCommissionFees");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Fees.EntranceCommissionFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CommissionFeeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CommisionPercentage")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<DateTime>("DateLastUpdated");

                    b.Property<bool>("IsCurrentRate");

                    b.HasKey("Id");

                    b.ToTable("EntranceCommissionFees");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.AffiliatedMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AffiliatedMemberID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeachClubMemberID");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .HasMaxLength(75);

                    b.Property<string>("LastName")
                        .HasMaxLength(75);

                    b.Property<int>("MemberAffiliation");

                    b.HasKey("Id");

                    b.HasIndex("BeachClubMemberID");

                    b.ToTable("AffiliatedMembers");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.MemberItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MemberItemID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeachClubMemberID");

                    b.Property<int>("MemberItemType");

                    b.Property<int>("StorageItemType");

                    b.HasKey("Id");

                    b.HasIndex("BeachClubMemberID");

                    b.ToTable("MemberItems");

                    b.HasDiscriminator<int>("MemberItemType");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.MemberItemInStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MemberItemInStorageID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BoatHouseRentalID");

                    b.Property<int?>("MemberItemID");

                    b.Property<string>("item");

                    b.HasKey("Id");

                    b.HasIndex("BoatHouseRentalID");

                    b.HasIndex("MemberItemID");

                    b.ToTable("MemberItemInStorage");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Rentals.BoatHouseRental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BoatHouseRentalID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeachClubMemberID");

                    b.Property<int>("BoatHouseID");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("HasBeenPaid");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("BeachClubMemberID");

                    b.HasIndex("BoatHouseID");

                    b.ToTable("BoatHouseRentals");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BeachClubMemberID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("BeachClubMembers");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BeachClubMemberClaimID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId")
                        .HasColumnName("BeachClubMemberID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BeachClubMemberClaims");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId")
                        .HasColumnName("BeachClubMemberID");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("BeachClubMemberLogins");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("BeachClubMemberID");

                    b.Property<int>("RoleId")
                        .HasColumnName("BeachClubRoleID");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("BeachClubMemberRoles");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("BeachClubMemberID");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("BeachClubMemberTokens");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BeachClubRoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("BeachClubRoles");
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BeachClubRoleClaimID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId")
                        .HasColumnName("BeachClubRoleID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("BeachClubRoleClaims");
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Addresses.ComplexAddress", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Addresses.Address");

                    b.Property<string>("ComplexName");

                    b.Property<string>("ComplexUnitNumber");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Addresses.POBoxAddress", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Addresses.Address");

                    b.Property<string>("POBoxNumber");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Addresses.StreetAddress", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Addresses.Address");

                    b.Property<string>("StreetName")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("StreetNumber");

                    b.ToTable("StreetAddresses");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.Boat", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Members.MemberItem");

                    b.Property<string>("BoatMake");

                    b.Property<string>("BoatModel");

                    b.Property<string>("BoatRegistration");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.JetSki", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Members.MemberItem");

                    b.Property<string>("JetSkiMake");

                    b.Property<string>("JetSkiModel");

                    b.Property<string>("JetSkiRegistration");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.MotorHome", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Members.MemberItem");

                    b.Property<string>("JetSkiMake")
                        .HasColumnName("MotorHome_JetSkiMake");

                    b.Property<string>("JetSkiModel")
                        .HasColumnName("MotorHome_JetSkiModel");

                    b.Property<string>("JetSkiRegistration")
                        .HasColumnName("MotorHome_JetSkiRegistration");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.Trailer", b =>
                {
                    b.HasBaseType("VaalBeachClub.Models.Domain.Members.MemberItem");

                    b.Property<string>("TrailerRegistration");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Addresses.Address", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "BeachClubMember")
                        .WithMany("Addresses")
                        .HasForeignKey("BeachClubMemberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.BoatHouses.BoatHouse", b =>
                {
                    b.HasOne("VaalBeachClub.Models.Domain.BoatHouses.BoatHouseSize", "BoatHouseSize")
                        .WithOne("BoatHouse")
                        .HasForeignKey("VaalBeachClub.Models.Domain.BoatHouses.BoatHouse", "BoatHouseSizeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Bookings.CampSiteBooking", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "BeachClubMember")
                        .WithMany("CampSiteBookings")
                        .HasForeignKey("BeachClubMemberID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VaalBeachClub.Models.Domain.CampSites.CampSite", "CampSite")
                        .WithMany("CampSiteBookings")
                        .HasForeignKey("CampSiteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Fees.BoatHouseCommissionFee", b =>
                {
                    b.HasOne("VaalBeachClub.Models.Domain.BoatHouses.BoatHouseSize")
                        .WithMany("BoatHouseCommissionFees")
                        .HasForeignKey("BoatHouseSizeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.AffiliatedMember", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "Member")
                        .WithMany("AffiliatedMembers")
                        .HasForeignKey("BeachClubMemberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.MemberItem", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "BeachClubMember")
                        .WithMany("MemberItems")
                        .HasForeignKey("BeachClubMemberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Members.MemberItemInStorage", b =>
                {
                    b.HasOne("VaalBeachClub.Models.Domain.Rentals.BoatHouseRental", "BoatHouseUseToStoreMemberItem")
                        .WithMany("MemberItemsInStorage")
                        .HasForeignKey("BoatHouseRentalID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VaalBeachClub.Models.Domain.Members.MemberItem", "MemberItemBeingStored")
                        .WithMany("MemberItemsInStorage")
                        .HasForeignKey("MemberItemID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VaalBeachClub.Models.Domain.Rentals.BoatHouseRental", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "BeachClubMember")
                        .WithMany("BoatHouseRentals")
                        .HasForeignKey("BeachClubMemberID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VaalBeachClub.Models.Domain.BoatHouses.BoatHouse", "BoatHouse")
                        .WithMany("BoatHouseRentals")
                        .HasForeignKey("BoatHouseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberClaim", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "Member")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberLogin", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "Member")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberRole", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "Member")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubMemberToken", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubMember", "Member")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VaalBeachClub.Web.Data.Identity.BeachClubRoleClaim", b =>
                {
                    b.HasOne("VaalBeachClub.Web.Data.Identity.BeachClubRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
