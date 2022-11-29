using Microsoft.EntityFrameworkCore;
using WebApplication1.Ozet.Entities;

namespace WebApplication1.Ozet.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
    }
}
