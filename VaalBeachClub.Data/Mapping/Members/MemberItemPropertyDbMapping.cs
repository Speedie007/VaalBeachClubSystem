using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
    public partial class MemberItemPropertyDbMapping : BeachClubEntityTypeConfiguration<MemberItemProperty>
    {
        public override void Configure(EntityTypeBuilder<MemberItemProperty> builder)
        {

            builder.HasKey(e => e.Id);
            builder.ToTable("MemberItemProperties");

            builder.Property(x => x.Id)
                 .HasColumnName("MemberItemPropertyID");



            builder.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

            builder.HasOne(d => d.ItemProperty)
                .WithMany(p => p.MemberAssetProperties)
                .HasForeignKey(d => d.ItemPropertyID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MemberItemProperties_ItemProperties_1");

            builder.HasOne(d => d.MemberItem)
                .WithMany(p => p.MemberAssetProperties)
                .HasForeignKey(d => d.MemberItemID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MemberItemProperties_MemberItems_1");



            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
