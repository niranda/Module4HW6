using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Entities;

namespace ShopApp.Helpers
{
    public class OnInitialize
    {
        private readonly ApplicationContext _context;
        private readonly InitializeDB _initializer;

        public OnInitialize(ApplicationContext context)
        {
            _context = context;
            _initializer = new InitializeDB(context);
        }

        public async Task Initialize()
        {
            await _initializer.InitArtists();
            await _initializer.InitGenres();
            await _initializer.InitSongs();
            await _initializer.InitArtistSongs();
        }
    }
}
