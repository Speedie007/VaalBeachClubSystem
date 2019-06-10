using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Files;

namespace VaalBeachClub.Data.Mapping.Common
{
    public partial class FileDbMapping : BeachClubEntityTypeConfiguration<File>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Files");

            builder.Property(x => x.Id)
               .HasColumnName("FileID");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ContentType)
                   .IsRequired()
                   .HasMaxLength(75)
                   .IsUnicode(false);

            builder.Property(e => e.FileExtension)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Image).HasColumnType("image");


            base.Configure(builder);
        }
    }
}