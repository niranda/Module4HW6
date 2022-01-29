using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApp.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title");
        }
    }
}