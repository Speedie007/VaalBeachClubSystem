using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Fees;

namespace VaalBeachClub.Data.Mapping.ClubFeeStructures
{
    public partial class BoatHouseCommissionFeeDbMapping : BeachClubEntityTypeConfiguration<BoatHouseCommissionFee>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BoatHouseCommissionFee> builder)
        {
            builder.ToTable("BoatHouseCommissionFees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("CommissionFeeID");

            builder.Property(x => x.CommisionPercentage)
            .HasColumnType("Decimal(18,2)");

            builder.HasOne(d => d.BoatHouseSize)
             .WithMany(p => p.BoatHouseCommissionFees)
             .HasForeignKey(d => d.BoatHouseSizeID);

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
