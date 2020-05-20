using System.Collections.Generic;

namespace CodeFitstTest.Data.Entities
{
    public class Destributor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
