using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFitstTest.Data.Entities
{
    [Table("Artist")]
    public class Artist
    {
        //[Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        public virtual ICollection<Song> Songs { get; set; } //= new List<Song>();
        public virtual ICollection<Destributor> Destributors { get; set; }
    }
}