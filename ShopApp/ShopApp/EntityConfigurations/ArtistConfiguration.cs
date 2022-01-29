using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name");
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnName("DateOfBirth");
            builder.Property(p => p.Phone).HasColumnName("Phone");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.InstagramUrl).HasColumnName("InstagramUrl");
        }
    }
}
