using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;

namespace VaalBeachClub.Data.Mapping.Items
{
    public partial class ItemPropertyDbMapping : BeachClubEntityTypeConfiguration<ItemProperty>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ItemProperty> builder)
        {
            builder.ToTable("ItemProperties");

            builder.Property(x => x.Id)
               .HasColumnName("ItemPropertyID");

            builder.HasKey(e => e.Id)
                     .HasName("PK_MemberItemProperties");

            builder.Property(e => e.Property)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);


            base.Configure(builder);
        }
    }
}
