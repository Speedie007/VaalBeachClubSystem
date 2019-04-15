using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using System.Reflection;


using System.Data;
using System.Data.Common;
using System.Linq;
using VaalBeachClub.Web.Data.Identity;
using VaalBeachClub.Models.Domain.BoatHouses;
using VaalBreachClub.Web.Data.Intefaces;
using VaalBeachClub.Data.Mapping;
using VaalBeachClub.Models.Domain.Addresses;
using VaalBeachClub.Models.Domain.Rentals;
using VaalBeachClub.Models.Domain.CampSites;
using VaalBeachClub.Models.Domain.Bookings;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Models.Domain.Fees;
using VaalBeachClub.Models.Domain.Logging;

namespace VaalBeachClub.Data
{
    public class ApplicationDbContext :
        IdentityDbContext<
                           BeachClubMember,
                            BeachClubRole,
                            int,
                            BeachClubMemberClaim,
                            BeachClubMemberRole,
                            BeachClubMemberLogin,
                            BeachClubRoleClaim,
                            BeachClubMemberToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        ////mUST ADD all classes that you need as tables in the database
        //public virtual DbSet<POBoxAddress> POBoxAddresses { get; set; }
        //public virtual DbSet<StreetAddress> StreetAddresses { get; set; }
        //public virtual DbSet<ComplexAddress> ComplexAddresses { get; set; }
        //public virtual DbSet<BoatHouse> BoatHouses { get; set; }
        //public virtual DbSet<BoatHouseRental> BoatHouseRentals { get; set; }
        //public virtual DbSet<AffiliatedMember> AffiliatedMembers { get; set; }
        //public virtual DbSet<BoatHouseSize> BoatHouseSizes { get; set; }
        //public virtual DbSet<CampSite> CampSites { get; set; }
        //public virtual DbSet<CampSiteBooking> CampSiteBookings { get; set; }

        //public virtual DbSet<MemberItem> MemberItems { get; set; }
        ////public virtual DbSet<Boat> Boats { get; set; }
        ////public virtual DbSet<Trailer> Trailers { get; set; }
        ////public virtual DbSet<JetSki> JetSkis { get; set; }
        ////public virtual DbSet<MotorHome> MotorHome { get; set; }
        //public virtual DbSet<CampSite> CampSites { get; set; }
        
        //public virtual DbSet<EntranceCommissionFee> EntranceCommissionFees { get; set; }
        //public virtual DbSet<BoatHouseCommissionFee> BoatHouseCommissionFees { get; set; }

        //public virtual DbSet<MemberItemInStorage> MemberItemsInStorage { get; set; }


        //logging
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<ActivityLogType> ActivityLogTypes { get; set; }
        public virtual DbSet<Log> Logs { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(BeachClubEntityTypeConfiguration<>)
                        || type.BaseType.GetGenericTypeDefinition() == typeof(BeachClubEntityTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }



            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BeachClubMember>(b =>
            {
                b.ToTable("BeachClubMembers");
                b.Property(x => x.Id).HasColumnName("BeachClubMemberID");

                // Each User can have one or many Items That Are Brought onto Site
                b.HasMany(e => e.MemberItems)
                    .WithOne(e => e.BeachClubMember)
                    .HasForeignKey(ul => ul.BeachClubMemberID)
                    .IsRequired();

                // Each User can have one or many Affiliations
                b.HasMany(e => e.AffiliatedMembers)
                    .WithOne(e => e.Member)
                    .HasForeignKey(ul => ul.BeachClubMemberID)
                    .IsRequired();

                // Each User can have many Address
                b.HasMany(e => e.Addresses)
                    .WithOne(e => e.BeachClubMember)
                    .HasForeignKey(ul => ul.BeachClubMemberID)
                    .IsRequired();

                // Each User can have many BoatLoackRentals
                b.HasMany(e => e.BoatHouseRentals)
                    .WithOne(e => e.BeachClubMember)
                    .HasForeignKey(ul => ul.BeachClubMemberID)
                    .IsRequired();

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.Member)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.Member)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.Member)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Member)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<BeachClubMemberClaim>(b =>
            {
                b.ToTable("BeachClubMemberClaims");
                b.Property(x => x.Id).HasColumnName("BeachClubMemberClaimID");
                b.Property(x => x.UserId).HasColumnName("BeachClubMemberID");
            });

            modelBuilder.Entity<BeachClubMemberLogin>(b =>
            {
                b.ToTable("BeachClubMemberLogins");
                b.Property(x => x.UserId).HasColumnName("BeachClubMemberID");
            });

            modelBuilder.Entity<BeachClubMemberToken>(b =>
            {
                b.ToTable("BeachClubMemberTokens");
                b.Property(x => x.UserId).HasColumnName("BeachClubMemberID");
            });

            modelBuilder.Entity<BeachClubRole>(b =>
            {
                b.ToTable("BeachClubRoles");
                b.Property(x => x.Id).HasColumnName("BeachClubRoleID");

                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<BeachClubRoleClaim>(b =>
           {
               b.ToTable("BeachClubRoleClaims");
               b.Property(x => x.Id).HasColumnName("BeachClubRoleClaimID");
               b.Property(x => x.RoleId).HasColumnName("BeachClubRoleID");
           });

            modelBuilder.Entity<BeachClubMemberRole>(b =>
            {
                b.ToTable("BeachClubMemberRoles");
                b.Property(x => x.UserId).HasColumnName("BeachClubMemberID");
                b.Property(x => x.RoleId).HasColumnName("BeachClubRoleID");
            });

        }
    }
}
