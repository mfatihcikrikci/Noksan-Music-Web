using Microsoft.EntityFrameworkCore;
using Noksan_Music_Web.Models;

namespace Noksan_Music_Web.Data
{
    public class NoksanMusicWebContext : DbContext
    {
        public NoksanMusicWebContext(DbContextOptions<NoksanMusicWebContext> options) : base(options)
        {
        }

        public DbSet<Mesaj> Mesajlar { get; set; } = null!;
    }
}