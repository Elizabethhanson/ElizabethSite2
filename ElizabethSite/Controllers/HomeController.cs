using System.Web.Mvc;
using ElizabethLibrary.Models;
using System.Collections.Generic;

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
