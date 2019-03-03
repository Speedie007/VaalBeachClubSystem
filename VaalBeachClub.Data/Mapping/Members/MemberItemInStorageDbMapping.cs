using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
    public partial class MemberItemInStorageDbMapping : BeachClubEntityTypeConfiguration<MemberItemInStorage>
    {
        public override void Configure(EntityTypeBuilder<MemberItemInStorage> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("MemberItemInStorageID");

            builder.ToTable("MemberItemInStorage");




            //builder.Property(x => x.FirstName)
            //    .HasMaxLength(75);
            //builder.Property(x => x.LastName)
            //    .HasMaxLength(75);


            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
