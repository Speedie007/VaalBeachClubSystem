using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Data.Mapping.Members
{
   public partial  class MemberRegistrationDbMapping : BeachClubEntityTypeConfiguration<MemberRegistration>
    {
        public override void Configure(EntityTypeBuilder<MemberRegistration> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("MemberRegistrationID");

            builder.ToTable("MemberRegistrations");


            builder.Property(e => e.DateRegistrationCreated)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.BeachClubMember)
                .WithMany(p => p.MemberRegistrations)
                .HasForeignKey(d => d.BeachClubMemberID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_MemberRegistrations_BeachClubMembers");


            base.Configure(builder);
        }

        public override void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            base.ApplyConfiguration(modelBuilder);


        }
    }
}
