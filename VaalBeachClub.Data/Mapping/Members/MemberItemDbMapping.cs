using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
    public partial class MemberItemDbMapping : BeachClubEntityTypeConfiguration<MemberItem>
    {
        public override void Configure(EntityTypeBuilder<MemberItem> builder)
        {

            builder.Property(x => x.Id)
                 .HasColumnName("MemberItemID");

            builder.ToTable("MemberItems");

           
            //.HasDiscriminator<MemberItemType>(nameof(MemberItemType))

            //.HasValue<Boat>(MemberItemType.Boat)
            //.HasValue<Trailer>(MemberItemType.Trailer)
            //.HasValue<JetSki>(MemberItemType.JetSki)
            //.HasValue<MotorHome>(MemberItemType.MotorHouses);

              builder.HasOne(d => d.BeachClubMember)
                    .WithMany(p => p.MemberItems)
                    .HasForeignKey(d => d.BeachClubMemberID);

            builder.HasOne(d => d.Item)
                .WithMany(p => p.MemberItems)
                .HasForeignKey(d => d.ItemID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MemberItems_ItemTypes");

            // Each User can have many BoatLoackRentals
            builder.HasMany(e => e.MemberItemsInStorage)
                .WithOne(e => e.MemberItemBeingStored)
                .HasForeignKey(ul => ul.MemberItemID)
                .OnDelete(DeleteBehavior.Restrict);




            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
