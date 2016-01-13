using LibraryService.Models;

namespace LibraryService.Entities
{
    public class EntityModelMapper
    {
        public static Book TranslateBookEntityToBook(BookEntity bookEntity)
        {
            Book book = new Book();
            book.AuthorId = bookEntity.AuthorId;
            book.BookId = bookEntity.BookEntityId;
            book.ISBN = bookEntity.ISBN;
            book.Title = bookEntity.Title;
            return book;
        }

        public static Author TranslateAuthorEntityToAuthor(AuthorEntity authorEntity)
        {
            Author author = new Author();
            author.AuthorID = authorEntity.AuthorEntityId;
            author.FirstName = authorEntity.FirstName;
            author.LastName = authorEntity.LastName;
            return author;
        }

        public static BookEntity TranslateBookToBookEntity(Book book)
        {
            BookEntity bookEntity = new BookEntity();
            bookEntity.AuthorId = book.AuthorId;
            bookEntity.BookEntityId = book.BookId;
            bookEntity.ISBN = book.ISBN;
            bookEntity.Title = book.Title;
            return bookEntity;
        }

        public static AuthorEntity TranslateAuthorToAuthorEntity(Author author)
        {
            AuthorEntity authorEntity = new AuthorEntity();
            authorEntity.AuthorEntityId = author.AuthorID;
            authorEntity.FirstName = author.FirstName;
            authorEntity.LastName = author.LastName;
            return authorEntity;
        }

    }
}
