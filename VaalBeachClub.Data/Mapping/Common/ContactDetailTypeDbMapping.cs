using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Common;

namespace VaalBeachClub.Data.Mapping.Common
{
    public partial class ContactDetailTypeDbMapping : BeachClubEntityTypeConfiguration<ContactDetailType>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ContactDetailType> builder)
        {
            builder.ToTable("ContactDetailTypes");

            builder.Property(x => x.Id)
               .HasColumnName("ContactDetailTypeID");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.ContactDetailTypeValue)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

            Array enumValueArray = Enum.GetValues(typeof(EnumContactDetailTypes));
            List<ContactDetailType> ListOfContactDetailTypes = new List<ContactDetailType>();
            foreach (int enumValue in enumValueArray)
            {
                ListOfContactDetailTypes.Add(new ContactDetailType()
                {
                    Id = enumValue,
                    ContactDetailTypeValue = Enum.GetName(typeof(EnumContactDetailTypes), enumValue).ToString().Replace("_", " ")
                });
            }

            builder.HasData(ListOfContactDetailTypes);

            base.Configure(builder);
        }
    }
}
