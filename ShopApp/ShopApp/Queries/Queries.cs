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

                    var res2 = result
                        .GroupBy(x => x.Song)
                        .Select(x => new { Title = x.Key.Title, Name = string.Join(",", x.Select(i => i.Artist.Name)), Genre = x.Key.Genre.Title });

                    foreach (var res in res2)
                    {
                        Console.WriteLine($"{res.Title} | {res.Name} | {res.Genre}");
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

        public async Task SecondQuery()
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = _context.Songs
                        .GroupBy(x => x.Genre.Title)
                        .Select(x => new { Name = x.Key, Count = x.Count() });

                    foreach (var res in result)
                    {
                        Console.WriteLine($"{res.Name} | {res.Count}");
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

        public async Task ThirdQuery()
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _context.Songs
                        .Where(x => x.ReleasedDate < _context.Artists.Max(p => p.DateOfBirth))
                        .ToListAsync();

                    foreach (var res in result)
                    {
                        Console.WriteLine($"{res.Title} | {res.Duration} | {res.Genre.Title} | {res.ReleasedDate}");
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
