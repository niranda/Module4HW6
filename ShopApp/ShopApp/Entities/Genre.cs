using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
