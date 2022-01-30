using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;

namespace ShopApp.Queries
{
    public class Queries
    {
        private readonly ApplicationContext _context;

        public Queries(ApplicationContext context)
        {
            _context = context;
        }

        public async Task FirstQuery()
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _context.ArtistSongs
                        .Include(x => x.Artist)
                        .Include(x => x.Song)
                        .ThenInclude(x => x.Genre)
                        .ToListAsync();

                    foreach (var res in result)
                    {
                        Console.WriteLine($"{res.Song.Title} | {res.Artist.Name} | {res.Song.Genre?.Title}");
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}
