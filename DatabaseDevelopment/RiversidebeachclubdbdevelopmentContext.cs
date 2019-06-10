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

        public virtual DbSet<ItemTypeHierarchy> ItemTypeHierarchy { get; set; }
        public virtual DbSet<ItemTypes> ItemTypes { get; set; }

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

            modelBuilder.Entity<ItemTypeHierarchy>(entity =>
            {
                entity.Property(e => e.ItemTypeHierarchyId).HasColumnName("ItemTypeHierarchyID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.ItemTypeHierarchy)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemTypeHierarchy_ItemTypes");
            });

            modelBuilder.Entity<ItemTypes>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}