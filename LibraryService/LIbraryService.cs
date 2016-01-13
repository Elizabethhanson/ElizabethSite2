using LibraryService.Models;
using LibraryService.Entities;
using System.Linq;
using System.Collections.Generic;

namespace LibraryService
{
    public class LibraryService : ILibraryService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }        

        public Book GetBook(int id)
        {
            LibraryContext context = new LibraryContext();
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
            LibraryContext context = new LibraryContext();
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
            LibraryContext context = new LibraryContext();
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
            LibraryContext context = new LibraryContext();
            var authorEntities = (from b in context.Authors select b).AsEnumerable<AuthorEntity>();

            List<Author> authors = new List<Author>();

            foreach (AuthorEntity authorEntity in authorEntities)
            {
                authors.Add(EntityModelMapper.TranslateAuthorEntityToAuthor(authorEntity));
            }

            return authors;
        }
    }
}
