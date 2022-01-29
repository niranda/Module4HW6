using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal Duration { get; set; }
        public DateTime ReleasedDate { get; set; }

        public List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();

        public Genre Genre { get; set; } = default!;
        public int GenreId { get; set; }
    }
}
