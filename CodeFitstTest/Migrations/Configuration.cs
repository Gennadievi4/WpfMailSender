namespace CodeFitstTest.Migrations
{
    using CodeFitstTest.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFitstTest.Data.TestSongsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFitstTest.Data.TestSongsDBContext context)
        {
            if (!context.Artists.Any())
            {
                context.Artists.AddOrUpdate(
                    new Artist
                    {
                        Name = "Исполнитель 1",
                    },
                    new Artist
                    {
                        Name = "Исполнитель 2",
                    },
                    new Artist
                    {
                        Name = "Исполнитель 3",
                    },
                    new Artist
                    {
                        Name = "Исполнитель 4",
                    });
            }
            if (!context.Destributors.Any())
            {
                context.Destributors.Add(new Destributor { Name = "Студия" });
                context.SaveChanges();
            }
        }
    }
}
