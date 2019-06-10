using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Common;

namespace VaalBeachClub.Data.Mapping.Common
{
    public partial class CountryDbMapping : BeachClubEntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.Property(x => x.Id)
               .HasColumnName("CountryID");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.CountryName)
                     .IsRequired()
                     .HasMaxLength(75)
                     .IsUnicode(false);

            builder.Property(e => e.CountryCode)
                   .IsRequired()
                   .HasMaxLength(2)
                   .IsUnicode(false);


            base.Configure(builder);
        }
    }
}
