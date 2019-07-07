using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
    public partial class MemberProfileImageDbMapping : BeachClubEntityTypeConfiguration<MemberProfileImage>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<MemberProfileImage> builder)
        {
            builder.ToTable("MemberProfileImages");

            builder.Property(e => e.Id)
              .HasColumnName("FileID")
              .ValueGeneratedNever();

            builder.HasKey(e => e.Id);


            builder.HasOne(d => d.BeachClubMember)
                .WithMany(p => p.MemberProfileImages)
                .HasForeignKey(d => d.BeachClubMemberID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MemberProfileImages_BeachClubMembers");

            builder.HasOne(d => d.File)
               .WithOne(p => p.MemberProfileImage)
               .HasForeignKey<MemberProfileImage>(d => d.Id)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_BeachClubFileBlobs_BeachClubFiles1");


            base.Configure(builder);
        }
    }
}