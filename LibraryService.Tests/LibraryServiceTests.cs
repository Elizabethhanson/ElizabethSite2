using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryService.Tests
{
    [TestClass]
    public class LibraryServiceTests
    {
        [TestMethod]
        public void TestGetBook()
        {
            LibraryService service = new LibraryService();
            var book = service.GetBook(1);
            Assert.IsNotNull(book);
        }
    }
}
