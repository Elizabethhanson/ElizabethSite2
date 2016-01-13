using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace LibraryService.Tests
{
    [TestClass]
    public class LibraryServiceTests
    {
        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        [TestMethod]
        public void TestGetBook()
        {
            LibraryService service = new LibraryService();
            var book = service.GetBook(1);
            Assert.IsNotNull(book);
        }

        [TestMethod]
        public void TestGetBooks()
        {
            LibraryService service = new LibraryService();
            var books = service.GetBooks();
            Assert.IsNotNull(books);
        }
    }
}
