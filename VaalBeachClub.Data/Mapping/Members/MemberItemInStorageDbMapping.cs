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


            builder.HasOne(d => d.MemberItemBeingStored)
                   .WithMany(p => p.MemberItemsInStorage)
                   .HasForeignKey(d => d.MemberItemID)
                   .OnDelete(DeleteBehavior.Restrict);

           

            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
