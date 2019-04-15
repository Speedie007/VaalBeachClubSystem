using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;

namespace VaalBeachClub.Data.Mapping.Items
{
    public partial class ItemTypePropertyDbMapping : BeachClubEntityTypeConfiguration<ItemTypeProperty>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ItemTypeProperty> builder)
        {
            builder.ToTable("ItemTypeProperties");

            builder.Property(x => x.Id)
               .HasColumnName("ItemTypePropertyID");

            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.Item)
                    .WithMany(p => p.ItemTypeProperties)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemTypeProperties_ItemTypes");

            builder.HasOne(d => d.ItemProperty)
                .WithMany(p => p.ItemTypeProperties)
                .HasForeignKey(d => d.ItemPropertyID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ItemTypeProperties_ItemProperties");


            base.Configure(builder);
        }
    }
}
