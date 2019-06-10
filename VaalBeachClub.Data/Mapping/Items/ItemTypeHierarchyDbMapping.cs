using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;

namespace VaalBeachClub.Data.Mapping.Items
{
    public partial class ItemTypeHierarchyDbMapping : BeachClubEntityTypeConfiguration<ItemTypeHierarchy>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ItemTypeHierarchy> builder)
        {
            builder.ToTable("ItemTypeHierarchy");

            builder.Property(x => x.Id)
               .HasColumnName("ItemTypeHierarchyID");

            builder.HasKey(e => e.Id);


            builder.HasOne(d => d.Parent)
                     .WithMany(p => p.ItemTypeHierarchy)
                     .HasForeignKey(d => d.ParentID)
                     .OnDelete(DeleteBehavior.Cascade)
                     .HasConstraintName("FK_ItemTypeHierarchy_ItemTypes");

            base.Configure(builder);
        }
    }
}
