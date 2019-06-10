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

             builder.HasData(
                 new BoatHouseSize()
                 {
                     Id = 1,
                      Description = "Boat Size A",
                     Hieght = Convert.ToDecimal(2.5),
                     Length = 8,
                     Width = 3,
                     Cost = 14380
                 },
                  new BoatHouseSize()
                  {
                      Id = 2,
                      Description = "Boat Size B",
                      Hieght = Convert.ToDecimal(2.8),
                      Length = 9,
                      Width = Convert.ToDecimal(3.5),
                      Cost = 16392
                  },
                   new BoatHouseSize()
                   {
                       Id = 3,
                       Description = "Boat Size C",
                       Hieght = Convert.ToDecimal(3.5),
                       Length = 9,
                       Width = Convert.ToDecimal(3.5),
                       Cost = 16392
                   },
                    new BoatHouseSize()
                    {
                        Id = 4,
                        Description = "Boat Size D",
                        Hieght = Convert.ToDecimal(4),
                        Length = 10,
                        Width = Convert.ToDecimal(3.5),
                        Cost = 18117
                    },
                     new BoatHouseSize()
                     {
                         Id = 5,
                         Description = "Boat Size E",
                         Hieght = Convert.ToDecimal(2.8),
                         Length = 12,
                         Width = Convert.ToDecimal(3.5),
                         Cost = 20340
                     },
                      new BoatHouseSize()
                      {
                          Id = 6,
                          Description = "Boat Size F",
                          Hieght = Convert.ToDecimal(3.5),
                          Length = 12,
                          Width = Convert.ToDecimal(3.5),
                          Cost = 20340
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