using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.EntityConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title");
            builder.Property(p => p.Duration).IsRequired().HasColumnName("Duration");
            builder.Property(p => p.ReleasedDate).IsRequired().HasColumnName("ReleasedDate");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Songs)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
