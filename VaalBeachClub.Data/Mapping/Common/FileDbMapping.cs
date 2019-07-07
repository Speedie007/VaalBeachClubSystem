using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Files;

namespace VaalBeachClub.Data.Mapping.Common
{
    public partial class FileDbMapping : BeachClubEntityTypeConfiguration<BeachClubFile>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BeachClubFile> builder)
        {
            builder.ToTable("BeachClubFiles");

            builder.Property(x => x.Id)
               .HasColumnName("FileID");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ContentType)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

            builder.Property(e => e.DateCreated).HasColumnType("datetime");

            builder.Property(e => e.FileExtension)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            // builder.Property(e => e.Image).HasColumnType("image");


            base.Configure(builder);
        }
    }
}