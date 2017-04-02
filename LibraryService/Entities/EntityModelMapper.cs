using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService.Entities
{
    public class EntityModelMapper
    {
        public static Book TranslateBookEntityToBook(BookEntity bookEntity)
        {
            var book = new Book();
            book.Author = TranslateAuthorEntityToAuthor(bookEntity.Author);
            book.BookId = bookEntity.Id;
            book.ISBN = bookEntity.ISBN;
            book.Title = bookEntity.Title;
            return book;
        }

        public static Author TranslateAuthorEntityToAuthor(AuthorEntity authorEntity)
        {
            var author = new Author();
            author.AuthorID = authorEntity.Id;
            author.FirstName = authorEntity.FirstName;
            author.LastName = authorEntity.LastName;
            author.Books = new List<Book>();

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
