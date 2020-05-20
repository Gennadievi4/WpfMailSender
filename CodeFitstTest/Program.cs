using CodeFitstTest.Data;
using System;
using System.Linq;

namespace CodeFitstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new TestSongsDBContext())
            {
                db.Database.Log = Console.WriteLine;

                foreach(var artist in db.Artists.Where(x => x.BirthDay < DateTime.Now))
                    foreach(var artist_song in artist.Songs)
                        Console.WriteLine(artist_song.Title);
            }
            Console.ReadLine();
        }
    }
}
