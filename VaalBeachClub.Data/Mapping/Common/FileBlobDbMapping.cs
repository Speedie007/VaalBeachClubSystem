using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Files;

namespace VaalBeachClub.Data.Mapping.Common
{
    public partial class FileBlobDbMapping : BeachClubEntityTypeConfiguration<FileBlob>
    {
        /// <summary>
        /// Configures the entity or class that mapps to the datbase table
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<FileBlob> builder)
        {
            builder.ToTable("FileBlobs");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("FileID")
                .ValueGeneratedNever();

            builder.Property(e => e.BlobData)
                .IsRequired()
                .HasColumnType("image");

            builder.HasOne(d => d.BeachClubFile)
                .WithOne(p => p.FileBlob)
                .HasForeignKey<FileBlob>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BeachClubFileBlobs_BeachClubFiles131123");

            base.Configure(builder);
        }
    }
}