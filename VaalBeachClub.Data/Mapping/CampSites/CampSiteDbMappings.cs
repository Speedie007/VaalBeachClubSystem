using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaalBeachClub.Models.Domain.CampSites;

namespace VaalBeachClub.Data.Mapping.CampSites
{
    public class CampSiteDbMapping : BeachClubEntityTypeConfiguration<CampSite>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CampSite> builder)
        {

            builder.Property(x => x.Id)
               .HasColumnName("CampSiteID");

            // Each CampSite can have many CampSiteBookings
            builder.HasMany(e => e.CampSiteBookings)
                .WithOne(e => e.CampSite)
                .HasForeignKey(ul => ul.CampSiteID)
                .IsRequired();


            base.Configure(builder);
        }
    }
}
