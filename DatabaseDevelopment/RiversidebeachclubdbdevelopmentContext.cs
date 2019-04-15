using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseDevelopment
{
    public partial class RiversidebeachclubdbdevelopmentContext : DbContext
    {
        public RiversidebeachclubdbdevelopmentContext()
        {
        }

        public RiversidebeachclubdbdevelopmentContext(DbContextOptions<RiversidebeachclubdbdevelopmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BeachClubMembers> BeachClubMembers { get; set; }
        public virtual DbSet<ItemProperties> ItemProperties { get; set; }
        public virtual DbSet<ItemTypeProperties> ItemTypeProperties { get; set; }
        public virtual DbSet<ItemTypes> ItemTypes { get; set; }
        public virtual DbSet<MemberItemInStorage> MemberItemInStorage { get; set; }
        public virtual DbSet<MemberItems> MemberItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RiverSideBeachClubDbDevelopment;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

          

            modelBuilder.Entity<ItemProperties>(entity =>
            {
               
            });

            modelBuilder.Entity<ItemTypeProperties>(entity =>
            {
               
            });

           

            modelBuilder.Entity<MemberItemInStorage>(entity =>
            {
              
            });

            modelBuilder.Entity<MemberItems>(entity =>
            {
                entity.HasKey(e => e.MemberItemId);

                entity.HasIndex(e => e.BeachClubMemberId);

                entity.Property(e => e.MemberItemId).HasColumnName("MemberItemID");

                entity.Property(e => e.BeachClubMemberId).HasColumnName("BeachClubMemberID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.HasOne(d => d.BeachClubMember)
                    .WithMany(p => p.MemberItems)
                    .HasForeignKey(d => d.BeachClubMemberId);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.MemberItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberItems_ItemTypes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}