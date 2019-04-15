using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;

namespace VaalBeachClub.Data.Mapping.Items
{
    public partial class ItemTypeDbMapping : BeachClubEntityTypeConfiguration<ItemType>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder.ToTable("ItemTypes");

            builder.Property(x => x.Id)
               .HasColumnName("ItemTypeID");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


            base.Configure(builder);
        }
    }
}
