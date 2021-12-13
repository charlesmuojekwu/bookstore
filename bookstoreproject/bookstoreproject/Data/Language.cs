using System.Collections.Generic;

namespace bookstoreproject.Data
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
