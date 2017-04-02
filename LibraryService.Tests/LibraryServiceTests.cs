using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var service = new LibraryService();
            var book = service.GetBook(1);
            Assert.IsNotNull(book);
        }

        [TestMethod]
        public void TestGetBooks()
        {
            var service = new LibraryService();
            var books = service.GetBooks();
            Assert.IsNotNull(books);
        }
    }
}
