using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Entities;

namespace ShopApp.Helpers
{
    public class InitializeDB
    {
        private readonly ApplicationContext _context;

        private readonly Artist _jackBowl;
        private readonly Artist _toddBush;
        private readonly Artist _leonardGeis;
        private readonly Artist _harlanDoyle;
        private readonly Artist _spikeWooldrige;

        private readonly Genre _altRock;
        private readonly Genre _edm;
        private readonly Genre _pop;
        private readonly Genre _hipHop;
        private readonly Genre _jazz;

        private readonly Song _night;
        private readonly Song _highLikeThis;
        private readonly Song _feel;
        private readonly Song _problems;
        private readonly Song _strangers;

        public InitializeDB(ApplicationContext context)
        {
            _context = context;

            _jackBowl = new Artist() { Name = "Jack Bowl", DateOfBirth = new DateTime(1946, 7, 20) };
            _toddBush = new Artist() { Name = "Todd Bush", DateOfBirth = new DateTime(1975, 7, 20) };
            _leonardGeis = new Artist() { Name = "Leonard Geis", DateOfBirth = new DateTime(1988, 7, 20) };
            _harlanDoyle = new Artist() { Name = "Harlan Doyle", DateOfBirth = new DateTime(1934, 7, 20) };
            _spikeWooldrige = new Artist() { Name = "Spike Woolridge", DateOfBirth = new DateTime(1995, 7, 20) };

            _altRock = new Genre() { Title = "Alternative Rock" };
            _edm = new Genre() { Title = "EDM" };
            _pop = new Genre() { Title = "Pop" };
            _hipHop = new Genre() { Title = "Hip-Hop" };
            _jazz = new Genre() { Title = "Jazz" };

            _night = new Song() { Title = "Night", Duration = 350, ReleasedDate = new DateTime(1992, 7, 20), Genre = _hipHop };
            _highLikeThis = new Song() { Title = "High Like This", Duration = 457, ReleasedDate = new DateTime(2011, 7, 20), Genre = _jazz };
            _feel = new Song() { Title = "Feel", Duration = 365, ReleasedDate = new DateTime(1955, 7, 20), Genre = _altRock };
            _problems = new Song() { Title = "Problems", Duration = 678, ReleasedDate = new DateTime(2003, 7, 20), Genre = _hipHop };
            _strangers = new Song() { Title = "Strangers", Duration = 240, ReleasedDate = new DateTime(1996, 7, 20), Genre = _pop };
        }

        public async Task InitArtists()
        {
            if (_context.Artists.Any())
            {
                return;
            }

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.AddRangeAsync(new List<Artist>()
                    {
                        _jackBowl,
                        _toddBush,
                        _leonardGeis,
                        _harlanDoyle,
                        _spikeWooldrige
                    });

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task InitGenres()
        {
            if (_context.Genres.Any())
            {
                return;
            }

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.AddRangeAsync(new List<Genre>()
                    {
                       _altRock,
                       _edm,
                       _pop,
                       _hipHop,
                       _jazz
                    });

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task InitSongs()
        {
            if (_context.Genres.Any())
            {
                return;
            }

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.AddRangeAsync(new List<Song>()
                    {
                        _night,
                        _highLikeThis,
                        _feel,
                        _problems,
                        _strangers
                    });

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e}");
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task InitArtistSongs()
        {
            if (_context.ArtistSongs.Any())
            {
                return;
            }

            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.AddRangeAsync(new List<ArtistSong>()
                    {
                        new ArtistSong() { Artist = _leonardGeis, Song = _problems },
                        new ArtistSong() { Artist = _leonardGeis, Song = _highLikeThis },
                        new ArtistSong() { Artist = _harlanDoyle, Song = _highLikeThis },
                        new ArtistSong() { Artist = _spikeWooldrige, Song = _strangers },
                        new ArtistSong() { Artist = _toddBush, Song = _night }
                    });

                    await _context.SaveChangesAsync();

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
