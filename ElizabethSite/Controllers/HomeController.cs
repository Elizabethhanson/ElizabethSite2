using System.Web.Mvc;

namespace ElizabethLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "My Library";
            return View();
        }
    }
}
