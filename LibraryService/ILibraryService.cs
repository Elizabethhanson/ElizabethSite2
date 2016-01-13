using System.ServiceModel;
using LibraryService.Models;
using System.Collections.Generic;

namespace LibraryService
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Book GetBook(int id);

        [OperationContract]
        IEnumerable<Book> GetBooks();

        [OperationContract]
        Author GetAuthor(int id);

        [OperationContract]
        IEnumerable<Author> GetAuthors();
    }

}
