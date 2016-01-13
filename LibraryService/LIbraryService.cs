using LibraryService.Models;
using LibraryService.Entities;
using System.Linq;
using System.Collections.Generic;

namespace LibraryService
{
    public class LibraryService : ILibraryService
    {
        public LibraryService()
        {
            context = new LibraryContext();
        }

        private LibraryContext context;

        public Book GetBook(int id)
        {
            var bookEntity = (from b in context.Books
                              where b.BookEntityId == id
                              select b).FirstOrDefault();
            if (bookEntity != null)
            {
                return EntityModelMapper.TranslateBookEntityToBook(bookEntity);
            }
            else
            {
                throw new System.Exception("Invalid book id");
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            var bookEntities = (from b in context.Books select b).AsEnumerable<BookEntity>();

            List<Book> books = new List<Book>();

            foreach (BookEntity bookEntity in bookEntities)
            {
                books.Add(EntityModelMapper.TranslateBookEntityToBook(bookEntity));
            }

            return books;
        }

        public Author GetAuthor(int id)
        {
            var authorEntity = (from a in context.Authors
                              where a.AuthorEntityId == id
                              select a).FirstOrDefault();
            if (authorEntity != null)
            {
                return EntityModelMapper.TranslateAuthorEntityToAuthor(authorEntity);
            }
            else
            {
                throw new System.Exception("Invalid author id");
            }
        }

        public IEnumerable<Author> GetAuthors()
        {
            var authorEntities = (from b in context.Authors select b).AsEnumerable<AuthorEntity>();

            List<Author> authors = new List<Author>();

            foreach (AuthorEntity authorEntity in authorEntities)
            {
                authors.Add(EntityModelMapper.TranslateAuthorEntityToAuthor(authorEntity));
            }

            return authors;
        }

        public IEnumerable<Book> GetBooksByAuthorID(int id)
        {
            var bookEntities = (from b in context.Books where b.AuthorId == id select b).AsEnumerable<BookEntity>();

            List<Book> books = new List<Book>();

            foreach (BookEntity bookEntity in bookEntities)
            {
                books.Add(EntityModelMapper.TranslateBookEntityToBook(bookEntity));
            }

            return books;
        }

        public void AddNewBook(Book book)
        {
            var bookEntity = EntityModelMapper.TranslateBookToBookEntity(book);
            context.Books.Add(bookEntity);
            context.SaveChanges();
        }

        public void AddNewAuthor(Author author)
        {
            var authorEntity = EntityModelMapper.TranslateAuthorToAuthorEntity(author);
            context.Authors.Add(authorEntity);
            context.SaveChanges();
        }

        public Book UpdateBook(Book book)
        {
            var bookEntity = (from b in context.Books
                              where b.BookEntityId == book.BookId
                              select b).FirstOrDefault();
            if (bookEntity == null)
            {
                throw new System.Exception("Invalid Book sent to update.  Did you mean to add it instead.");
            }
            else
            {
                bookEntity.AuthorId = book.AuthorId;
                bookEntity.ISBN = book.ISBN;
                bookEntity.Title = book.Title;
            }
            context.SaveChanges();
            return book;
        }

        public Author UpdateAuthor(Author author)
        {
            var authorEntity = (from b in context.Authors
                              where b.AuthorEntityId == author.AuthorID
                              select b).FirstOrDefault();
            if (authorEntity == null)
            {
                throw new System.Exception("Invalid Author sent to update.  Did you mean to add it instead.");
            }
            else
            {
                authorEntity.FirstName = author.FirstName;
                authorEntity.LastName = author.LastName;
            }
            context.SaveChanges();
            return author;
        }
    }
}
