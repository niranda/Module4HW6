using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; }

        public List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
