using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService.Entities
{
    public class EntityModelMapper
    {
        public static Book TranslateBookEntityToBook(BookEntity bookEntity)
        {
            var book = new Book
            {
                Author = TranslateAuthorEntityToAuthor(bookEntity.Author),
                BookId = bookEntity.Id,
                ISBN = bookEntity.ISBN,
                Title = bookEntity.Title
            };
            return book;
        }

        public static Author TranslateAuthorEntityToAuthor(AuthorEntity authorEntity)
        {
            var author = new Author
            {
                AuthorID = authorEntity.Id,
                FirstName = authorEntity.FirstName,
                LastName = authorEntity.LastName,
                Books = new List<Book>()
            };

            foreach (var bookEntity in authorEntity.Books)
            {
                author.Books.Add(TranslateBookEntityToBook(bookEntity));
            }

            return author;
        }

        public static BookEntity TranslateBookToBookEntity(Book book, BookEntity bookEntity, AuthorEntity authorEntity)
        {
            bookEntity.Author = TranslateAuthorToAuthorEntity(book.Author, authorEntity);
            bookEntity.Id = book.BookId;
            bookEntity.ISBN = book.ISBN;
            bookEntity.Title = book.Title;
            return bookEntity;
        }

        public static AuthorEntity TranslateAuthorToAuthorEntity(Author author, AuthorEntity authorEntity)
        {
            authorEntity.Id = author.AuthorID;
            authorEntity.FirstName = author.FirstName;
            authorEntity.LastName = author.LastName;
            return authorEntity;
        }

    }
}
