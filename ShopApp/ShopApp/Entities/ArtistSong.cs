using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class ArtistSong
    {
        public int Id { get; set; }

        public Artist Artist { get; set; } = default!;
        public int ArtistId { get; set; }
        public Song Song { get; set; } = default!;
        public int SongId { get; set; }
    }
}
