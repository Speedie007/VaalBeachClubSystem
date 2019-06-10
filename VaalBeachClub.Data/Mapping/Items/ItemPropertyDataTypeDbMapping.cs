using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Items;

namespace VaalBeachClub.Data.Mapping.Items
{
    public class ItemPropertyDataTypeDbMapping : BeachClubEntityTypeConfiguration<ItemPropertyDataType>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ItemPropertyDataType> builder)
        {
            builder.ToTable("ItemPropertyDataTypes");

            builder.Property(x => x.Id)
               .HasColumnName("ItemPropertyDataTypeID");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.ItemPropertyDataTypeName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);


            //EnumAssetPropertyDataTypes

            Array enumValueArray = Enum.GetValues(typeof(EnumAssetPropertyDataTypes));
            List<ItemPropertyDataType> ListOfItemTypes = new List<ItemPropertyDataType>();
            foreach (int enumValue in enumValueArray)
            {
                ListOfItemTypes.Add(new ItemPropertyDataType()
                {
                    Id = enumValue,
                    ItemPropertyDataTypeName = Enum.GetName(typeof(EnumAssetPropertyDataTypes), enumValue).ToString().Replace("_", " ")
                });
            }

            builder.HasData(ListOfItemTypes);


            base.Configure(builder);
        }
    }
}
