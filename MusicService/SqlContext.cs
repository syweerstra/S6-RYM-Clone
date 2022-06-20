using Microsoft.EntityFrameworkCore;
using MusicService.Models;

namespace MusicService
{
    public class SqlContext : DbContext
    {
        public DbSet<Album> MusicRelease { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Artist> Artist { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
    }
}
