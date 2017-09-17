using System.Data.Entity;

namespace LibraryService.Entities
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }

        public LibraryContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
    }

    public class LibraryInitializer: DropCreateDatabaseAlways<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        { 
            const string fileName = "C:\\Users\\elizabeth\\Source\\Repos\\ElizabethSite2\\LibraryService\\JsonSeedFiles\\SeedData.json";
            var authors = SeedHelper.SeedIt<AuthorEntity>(fileName);
            context.Authors.AddRange(authors);
            base.Seed(context);
        }
    }
}
