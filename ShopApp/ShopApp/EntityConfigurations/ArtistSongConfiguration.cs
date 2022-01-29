using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.EntityConfigurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.ArtistSongs)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Song)
                .WithMany(p => p.ArtistSongs)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
