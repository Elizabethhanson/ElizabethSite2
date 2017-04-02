using System.Web.Mvc;
using ElizabethLibrary.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElizabethSite.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("My Library", result.ViewBag.Title);
        }
    }
}
