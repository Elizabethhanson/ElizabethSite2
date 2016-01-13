using System.ServiceModel;
using LibraryService.Models;

namespace LibraryService
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Book GetBook(int id);
    }

}
