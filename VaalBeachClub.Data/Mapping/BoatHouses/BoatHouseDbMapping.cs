﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaalBeachClub.Models.Domain.BoatHouses;

namespace VaalBeachClub.Data.Mapping.BoatHouses
{
    public partial class BoatHouseDbMapping : BeachClubEntityTypeConfiguration<BoatHouse>
    {
        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BoatHouse> builder)
        {

            builder.ToTable("BoatHouses");

            builder.Property(x => x.Id)
                .HasColumnName("BoatHouseID");


            builder.HasKey(boathouse => boathouse.Id);

            builder.Property(boathouse => boathouse.BoatHouseNumber)
                .HasMaxLength(250)
                .HasColumnName("BoatHouseNumber");

            // Each User can have many BoatLoackRentals
            builder.HasMany(e => e.BoatHouseRentals)
                .WithOne(e => e.BoatHouse)
                .HasForeignKey(ul => ul.BoatHouseID)
                .IsRequired();

            // Each Boathouse can have many sizes
            builder.HasOne(d => d.BoatHouseSize)
                    .WithMany(p => p.BoatHouses)
                    .HasForeignKey(d => d.BoatHouseSizeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BoatHouses_BoatHouseSizes");

            builder.HasData(
                new BoatHouse()
                {
                    Id = 1,
                    BoatHouseNumber = "BH001",
                    BoatHouseSizeID = 1
                },
                new BoatHouse()
                {
                    Id = 2,
                    BoatHouseNumber = "BH002",
                    BoatHouseSizeID = 2
                },
                new BoatHouse()
                {
                    Id = 3,
                    BoatHouseNumber = "BH003",
                    BoatHouseSizeID = 3
                },
                new BoatHouse()
                {
                    Id = 4,
                    BoatHouseNumber = "BH004",
                    BoatHouseSizeID = 4
                },
                new BoatHouse()
                {
                    Id = 5,
                    BoatHouseNumber = "BH005",
                    BoatHouseSizeID = 5
                },
                new BoatHouse()
                {
                    Id = 6,
                    BoatHouseNumber = "BH006",
                    BoatHouseSizeID = 6
                }
                );


            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }

    }
}
