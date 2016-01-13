using LibraryService.Models;

namespace LibraryService.Entities
{
    public class EntityModelMapper
    {
        public static Book TranslateBookEntityToBook(BookEntity bookEntity)
        {
            Book book = new Book();
            book.AuthorId = bookEntity.AuthorId;
            book.BookId = bookEntity.BookId;
            book.ISBN = bookEntity.ISBN;
            book.Title = bookEntity.Title;
            return book;
        }

        public static Author TranslateAuthorEntityToAuthor(AuthorEntity authorEntity)
        {
            Author author = new Author();
            author.AuthorID = authorEntity.AuthorId;
            author.FirstName = authorEntity.FirstName;
            author.LastName = authorEntity.LastName;
            return author;
        }

    }
}
