using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.EntityConfigurations;

namespace ShopApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<ArtistSong> ArtistSongs { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistSongConfiguration());
        }
    }
}
