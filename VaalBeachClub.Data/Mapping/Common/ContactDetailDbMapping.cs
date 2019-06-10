using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Common;

namespace VaalBeachClub.Data.Mapping.Common
{
    public partial class ContactDetailDbMapping : BeachClubEntityTypeConfiguration<ContactDetail>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ContactDetail> builder)
        {
            builder.ToTable("ContactDetails");

            builder.Property(x => x.Id)
               .HasColumnName("ContactDetailID");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ContactDetailValue)
                               .IsRequired()
                               .HasMaxLength(150)
                               .IsUnicode(false);

            builder.HasOne(d => d.BeachClubMember)
                .WithMany(p => p.ContactDetails)
                .HasForeignKey(d => d.BeachClubMemberID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ContactDetails_BeachClubMembers");

            builder.HasOne(d => d.ContactDetailType)
                .WithMany(p => p.ContactDetails)
                .HasForeignKey(d => d.ContactDetailTypeID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ContactDetails_ContactDetailTypes");


            base.Configure(builder);
        }
    }
}
