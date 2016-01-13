using System.Data.Entity;

namespace LibraryService.Entities
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
    }
}
