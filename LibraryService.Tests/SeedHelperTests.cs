using System.Collections.Generic;
using LibraryService.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryService.Tests
{
    [TestClass]
    public class SeedHelperTests
    {
        [TestMethod]
        public void TestSeedHelperDeserializeFile()
        {
            // Arrange
            var helper = new SeedHelper();
            var fileName = "C:\\Users\\elizabeth\\Source\\Repos\\ElizabethSite2\\LibraryService\\JsonSeedFiles\\SeedData.json";

            // Act
            var result = SeedHelper.SeedIt<AuthorEntity>(fileName);

            // Assert<
            Assert.IsInstanceOfType(result, typeof(List<AuthorEntity>));
        }

    }
}
