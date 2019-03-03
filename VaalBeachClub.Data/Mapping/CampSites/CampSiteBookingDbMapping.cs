using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Bookings;

namespace VaalBeachClub.Data.Mapping.CampSites
{
    public partial class CampSiteBookingDbMapping : BeachClubEntityTypeConfiguration<CampSiteBooking>
    {
        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CampSiteBooking> builder)
        {


            builder.Property(x => x.Id)
                .HasColumnName("CampSiteBookingID");

            builder.ToTable("CampSiteBookings");
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.StartDateTime)
            //    .HasMaxLength(250)
            //    .HasColumnType<DateTime>("DateTime")
            //    .HasDefaultValue("GetDate()")
            //    .HasColumnName("StartDateTime");

            



            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {

            base.ApplyConfiguration(modelBuilder);


        }
    }
}
