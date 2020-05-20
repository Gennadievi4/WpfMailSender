using CodeFitstTest.Data.Entities;
using CodeFitstTest.Migrations;
using System.Data.Entity;

namespace CodeFitstTest.Data
{
    public class TestSongsDBContext : DbContext
    {
        //static TestSongsDBContext() => Database.SetInitializer(new DropCreateDatabaseAlways<TestSongsDBContext>()); - для пересоздания базы данных
        //static TestSongsDBContext() => Database.SetInitializer(new CreateDatabaseIfNotExists<TestSongsDBContext>());
        static TestSongsDBContext() => Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestSongsDBContext, Configuration>());
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Destributor> Destributors { get; set; }
        public DbSet<Song> Songs { get; set; }
        public TestSongsDBContext() : this("DefaultConnection") { }
        public TestSongsDBContext(string ConnectionString) : base(ConnectionString)
        {

        }
    }
}
