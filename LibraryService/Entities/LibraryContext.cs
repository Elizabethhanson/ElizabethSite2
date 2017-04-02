using System.Collections.Generic;
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

    public class LibraryInitializer: DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            new List<BookEntity>
            {
                new BookEntity {Title="Elantris", ISBN="1234-1234-1234", Author= new AuthorEntity {FirstName="Brandon", LastName="Sanderson" } },
                new BookEntity {Title="A Game of Thrones", ISBN="A123-B2345-C1234", Author = new AuthorEntity {FirstName="George", LastName="Martin" } }
            }.ForEach(b => context.Books.Add(b));
            base.Seed(context);
        }
    }
}
