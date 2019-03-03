using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeachClubDBReverseEng
{
    public partial class RiverSideBeachClubDbDevelopmentContext : DbContext
    {
        public RiverSideBeachClubDbDevelopmentContext()
        {
        }

        public RiverSideBeachClubDbDevelopmentContext(DbContextOptions<RiverSideBeachClubDbDevelopmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<BeachClubRoleClaims> BeachClubRoleClaims { get; set; }
        public virtual DbSet<BeachClubRoles> BeachClubRoles { get; set; }
        public virtual DbSet<BeachClubUserClaims> BeachClubUserClaims { get; set; }
        public virtual DbSet<BeachClubUserLogins> BeachClubUserLogins { get; set; }
        public virtual DbSet<BeachClubUserRoles> BeachClubUserRoles { get; set; }
        public virtual DbSet<BeachClubUserTokens> BeachClubUserTokens { get; set; }
        public virtual DbSet<BeachClubUsers> BeachClubUsers { get; set; }
        public virtual DbSet<BoatHouses> BoatHouses { get; set; }
        public virtual DbSet<ComplexAddress> ComplexAddress { get; set; }
        public virtual DbSet<PoboxAddress> PoboxAddress { get; set; }
        public virtual DbSet<StreetAddress> StreetAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Password=Password!;Persist Security Info=True;User ID=sa;Initial Catalog=RiverSideBeachClubDbDevelopment;Data Source=DESKTOP-BLJSHVF;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<BeachClubRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.BeachClubRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<BeachClubRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<BeachClubUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BeachClubUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BeachClubUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BeachClubUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BeachClubUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.BeachClubUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BeachClubUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BeachClubUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BeachClubUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BeachClubUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BoatHouses>(entity =>
            {
                entity.Property(e => e.BoatHouseNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComplexAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ComplexName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ComplexNumber).HasMaxLength(10);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ComplexAddress)
                    .HasForeignKey<ComplexAddress>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplexAddress_Addresses");
            });

            modelBuilder.Entity<PoboxAddress>(entity =>
            {
                entity.ToTable("POBoxAddress");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PoboxNumber)
                    .IsRequired()
                    .HasColumnName("POBoxNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PoboxAddress)
                    .HasForeignKey<PoboxAddress>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_POBoxAddress_Addresses");
            });

            modelBuilder.Entity<StreetAddress>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StreetName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.StreetAddress)
                    .HasForeignKey<StreetAddress>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StreetAddress_Addresses");
            });
        }
    }
}
