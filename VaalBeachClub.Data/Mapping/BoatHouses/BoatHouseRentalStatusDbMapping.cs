using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.Domain.Rentals;

namespace VaalBeachClub.Data.Mapping.BoatHouses
{
    public partial class BoatHouseRentalStatusDbMapping : BeachClubEntityTypeConfiguration<BoatHouseRentalStatus>
    {
        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BoatHouseRentalStatus> builder)
        {

            builder.ToTable("BoatHouseRentalStatuses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("BoatHouseRentalStatusID");



            builder.HasMany(x => x.BoatHouseRentals)
                .WithOne(x => x.BoatHouseRentalStatus)
                .HasForeignKey(x => x.BoatHouseRentalStatusID)
                .OnDelete(DeleteBehavior.Restrict);


            //EnumBoatHouseRentalStatuses
            Array enumValueArray = Enum.GetValues(typeof(EnumBoatHouseRentalStatuses));
            List<BoatHouseRentalStatus> ListOfItemTypes = new List<BoatHouseRentalStatus>();
            foreach (int enumValue in enumValueArray)
            {
                ListOfItemTypes.Add(new BoatHouseRentalStatus()
                {
                    Id = enumValue,
                    RentalStatus = Enum.GetName(typeof(EnumBoatHouseRentalStatuses), enumValue).ToString().Replace("_", " ")
                });
            }

            builder.HasData(ListOfItemTypes);

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }

    }
}

