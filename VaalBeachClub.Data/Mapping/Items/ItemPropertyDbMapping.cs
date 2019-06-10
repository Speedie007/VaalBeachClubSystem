using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Items;

namespace VaalBeachClub.Data.Mapping.Items
{
    public partial class ItemPropertyDbMapping : BeachClubEntityTypeConfiguration<ItemProperty>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ItemProperty> builder)
        {
            builder.ToTable("ItemProperties");

            builder.Property(x => x.Id)
               .HasColumnName("ItemPropertyID");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Property)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.ItemPropertyDataType)
                    .WithMany(p => p.ItemProperties)
                    .HasForeignKey(d => d.ItemPropertyDataTypeID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemProperties_ItemPropertyDataTypes");

            Array enumValueArray = Enum.GetValues(typeof(EnumAssestProperties));
            List<ItemProperty> ListOfItemTypes = new List<ItemProperty>();
            foreach (int enumValue in enumValueArray)
            {
                var FKValue = 1;
                if ("Length" == Enum.GetName(typeof(EnumAssestProperties), enumValue)
                    || "Height" == Enum.GetName(typeof(EnumAssestProperties), enumValue)
                    || "" == Enum.GetName(typeof(EnumAssestProperties), enumValue))
                {
                    FKValue = 2;
                }
                ListOfItemTypes.Add(new ItemProperty()
                {
                    Id = enumValue,
                    ItemPropertyDataTypeID = FKValue,
                    Property = Enum.GetName(typeof(EnumAssestProperties), enumValue).ToString().Replace("_", " ")
                });
            }

            builder.HasData(ListOfItemTypes);

            //builder.HasData(
            //    new ItemProperty()
            //    {
            //        Id = 1,
            //         ItemPropertyDataTypeID  = 1,
            //        Property = "Colour"
            //    },
            //    new ItemProperty()
            //    {
            //        Id = 2,
            //        ItemPropertyDataTypeID = 1,
            //        Property = "Registration Number"
            //    },
            //     new ItemProperty()
            //     {
            //         Id = 3,
            //         ItemPropertyDataTypeID = 1,
            //         Property = "Boat Name"
            //     },
            //      new ItemProperty()
            //      {
            //          Id = 4,
            //          ItemPropertyDataTypeID = 1,
            //          Property = "Make"
            //      },
            //       new ItemProperty()
            //       {
            //           Id = 5,
            //           ItemPropertyDataTypeID = 2,
            //           Property = "Length"
            //       },
            //       new ItemProperty()
            //       {
            //           Id = 6,
            //           ItemPropertyDataTypeID = 2,
            //           Property = "Height"
            //       }
            //   );


            base.Configure(builder);
        }
    }
}
