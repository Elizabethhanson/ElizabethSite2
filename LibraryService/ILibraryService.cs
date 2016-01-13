using System.ServiceModel;
using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        Book GetBook(int id);

        [OperationContract]
        IEnumerable<Book> GetBooks();

        [OperationContract]
        Author GetAuthor(int id);

        [OperationContract]
        IEnumerable<Author> GetAuthors();

        [OperationContract]
        IEnumerable<Book> GetBooksByAuthorID(int id);

        [OperationContract]
        void AddNewBook(Book book);

        [OperationContract]
        void AddNewAuthor(Author author);

        [OperationContract]
        Book UpdateBook(Book book);

        [OperationContract]
        Author UpdateAuthor(Author author);
    }

}
