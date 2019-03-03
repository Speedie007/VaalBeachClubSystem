using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.BoatHouses;

namespace VaalBeachClub.Data.Mapping.BoatHouses
{
    public partial class BoatHouseSizeDbMapping : BeachClubEntityTypeConfiguration<BoatHouseSize>
    {/// <summary>
     /// Configures the entity
     /// </summary>
     /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BoatHouseSize> builder)
        {

            builder.Property(x => x.Id)
                .HasColumnName("BoatHouseSizeID");

            builder.Property(x => x.Cost)
            .HasColumnType("Money");
            //each Boat house has only one size
            builder
                .HasOne(a => a.BoatHouse)
                .WithOne(b => b.BoatHouseSize)
                .HasForeignKey<BoatHouse>(b => b.BoatHouseSizeID);

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}