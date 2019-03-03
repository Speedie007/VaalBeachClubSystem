using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Addresses;

namespace VaalBeachClub.Data.Mapping.Addresses
{
    public class StreetAddressDbMapping : BeachClubEntityTypeConfiguration<StreetAddress>
    {

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<StreetAddress> builder)
        {
            builder.ToTable("StreetAddresses");
            //builder.HasKey(x => x.Id);

            builder.Property(x => x.StreetName)
                .HasMaxLength(250)
                .HasColumnType("varchar(250)");

            base.Configure(builder);
        }
    }
}
