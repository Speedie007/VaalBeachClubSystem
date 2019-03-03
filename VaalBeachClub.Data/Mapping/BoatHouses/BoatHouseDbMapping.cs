using Microsoft.EntityFrameworkCore;
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


            builder.Property(x => x.Id)
                .HasColumnName("BoatHouseID");

            builder.ToTable("BoatHouses");
            builder.HasKey(boathouse => boathouse.Id);

            builder.Property(boathouse => boathouse.BoatHouseNumber)
                .HasMaxLength(250)
                .HasColumnName("BoatHouseNumber");

            // Each User can have many BoatLoackRentals
            builder.HasMany(e => e.BoatHouseRentals)
                .WithOne(e => e.BoatHouse)
                .HasForeignKey(ul => ul.BoatHouseID)
                .IsRequired();

           

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }

    }
}
