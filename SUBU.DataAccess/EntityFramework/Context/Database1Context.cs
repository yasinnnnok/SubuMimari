using Microsoft.EntityFrameworkCore;
using SUBU.Entities.EntityFramework.Database1;

namespace SUBU.DataAccess.EntityFramework.Context
{
    public class Database1Context : DbContext
    {
        public Database1Context(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
