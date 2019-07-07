using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Common;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
   public partial  class AffiliatedMemberTypeDbMapping : BeachClubEntityTypeConfiguration<AffiliatedMemberType>
    {
        public override void Configure(EntityTypeBuilder<AffiliatedMemberType> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("AffiliatedMemberTypeID");

            builder.ToTable("AffiliatedMemberTypes");

           
            builder.Property(e => e.AffiliatedMemberTypeName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            Array enumValueArray = Enum.GetValues(typeof(EnumAffiliatedMemberType));
            List<AffiliatedMemberType> ListOfAffiliatedMemberTypes = new List<AffiliatedMemberType>();
            foreach (int enumValue in enumValueArray)
            {
                ListOfAffiliatedMemberTypes.Add(new AffiliatedMemberType()
                {
                    Id = enumValue,
                    AffiliatedMemberTypeName = Enum.GetName(typeof(EnumAffiliatedMemberType), enumValue).ToString().Replace("_", " ")
                });
            }
            builder.HasData(ListOfAffiliatedMemberTypes);


            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
