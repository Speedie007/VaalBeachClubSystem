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
            builder.ToTable("BoatHouseSizes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("BoatHouseSizeID");


            builder.Property(e => e.Cost).HasColumnType("money");

            builder.Property(e => e.Hieght).HasColumnType("numeric(18, 1)");

            builder.Property(e => e.Length).HasColumnType("numeric(18, 1)");

            builder.Property(e => e.Width).HasColumnType("numeric(18, 1)");

            //builder.Property(e => e.Dimensions)..ValueGeneratedNever();

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}