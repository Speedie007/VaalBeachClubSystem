using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Fees;

namespace VaalBeachClub.Data.Mapping.ClubFeeStructures
{
    public partial class ClubFeeStructureDbMapping : BeachClubEntityTypeConfiguration<BeachClubFeeStructure>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BeachClubFeeStructure> builder)
        {
            builder.ToTable("BeachClubFeeStructures");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("BeachClubFeeStructureID");

            builder.Property(x => x.CampSitePerNight)
            .HasColumnType("Money");

            builder.Property(x => x.CampSitePerPersonForMembers)
            .HasColumnType("Money");

            builder.Property(x => x.CampSitePerPersonForNonMembers)
            .HasColumnType("Money");

            builder.Property(x => x.MemberEntranceFee)
            .HasColumnType("Money");

            builder.Property(x => x.NonMemberBoatEntranceFee)
            .HasColumnType("Money");

            builder.Property(x => x.NonMemberEntranceFee)
            .HasColumnType("Money");

            builder.Property(x => x.NonMemberJetSkiEntranceFee)
            .HasColumnType("Money");

            builder.Property(x => x.NonMemberVehicleEntranceFee)
            .HasColumnType("Money");

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
