using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Addresses;

namespace VaalBeachClub.Data.Mapping.Addresses
{
    public class AddressDbMapping : BeachClubEntityTypeConfiguration<Address>
    {

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses")
                .Property(x => x.Id).HasColumnName("AddressID");
            builder.Property(x => x.BeachClubMemberID).HasColumnName("BeachClubMemberID");



            builder.ToTable("Addresses")
                .HasDiscriminator<AddressTypes>("AddressType")
                .HasValue<StreetAddress>(AddressTypes.StreetAddress)
            .HasValue<POBoxAddress>(AddressTypes.POBoxAddress)
            .HasValue<ComplexAddress>(AddressTypes.ComplexAddress);

            base.Configure(builder);
        }
    }
}
