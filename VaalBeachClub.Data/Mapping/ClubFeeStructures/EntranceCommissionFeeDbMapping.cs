using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Fees;

namespace VaalBeachClub.Data.Mapping.ClubFeeStructures
{
    public partial class EntranceCommissionFeeDbMapping : BeachClubEntityTypeConfiguration<EntranceCommissionFee>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<EntranceCommissionFee> builder)
        {
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("CommissionFeeID");

            builder.Property(x => x.CommisionPercentage)
            .HasColumnType("Decimal(18,2)");

           

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
