using CodeFitstTest.Data.Entities;
using System.Data.Entity;

namespace CodeFitstTest.Data
{
    public class TestSongsDBContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Destributor> Destributors { get; set; }
        public DbSet<Song> Songs { get; set; }
        public TestSongsDBContext() : this("DefaultConnection") { }
        public TestSongsDBContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
