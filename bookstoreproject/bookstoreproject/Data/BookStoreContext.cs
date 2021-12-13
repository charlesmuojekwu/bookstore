using Microsoft.EntityFrameworkCore;

namespace bookstoreproject.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Books> books { get; set; }
        public DbSet<Language> languages { get; set; }
        
    }
}
