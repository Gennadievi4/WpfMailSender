using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFitstTest.Data.Entities
{
    public class Song
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        public double Length { get; set; }

        //[ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }
    }
}
