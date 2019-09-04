using System.Web.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Home controller class
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Home index view
        /// </summary>
        /// <returns>Home index view</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
