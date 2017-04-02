using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDataAccess _dataAccess;

        public LibraryService()
        {
            _dataAccess = new LibraryDataAccess();
        }

        public Book GetBook(int id)
        {
            return _dataAccess.GetBook(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dataAccess.GetBooks();
        }

        public Author GetAuthor(int id)
        {
            return _dataAccess.GetAuthor(id);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _dataAccess.GetAuthors();
        }

        public IEnumerable<Book> GetBooksByAuthorID(int id)
        {
            return _dataAccess.GetBooksByAuthorId(id);
        }

        public void AddNewBook(Book book)
        {
            _dataAccess.AddNewBook(book);         
        }

        public void AddNewAuthor(Author author)
        {
            _dataAccess.AddNewAuthor(author);
        }

        public Book UpdateBook(Book book)
        {
            return _dataAccess.UpdateBook(book);
        }

        public Author UpdateAuthor(Author author)
        {
            return _dataAccess.UpdateAuthor(author);
        }
    }
}
