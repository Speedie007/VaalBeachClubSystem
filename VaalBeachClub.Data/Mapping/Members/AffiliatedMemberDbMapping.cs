using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
    public class AffiliatedMemberDbMapping : BeachClubEntityTypeConfiguration<AffiliatedMember>
    {
        public override void Configure(EntityTypeBuilder<AffiliatedMember> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("AffiliatedMemberID");

            builder.ToTable("AffiliatedMembers");


            builder.Property(x => x.FirstName)
                .HasMaxLength(75);
            builder.Property(x => x.LastName)
                .HasMaxLength(75);


            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
