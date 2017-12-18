using System.Web.Mvc;

namespace ChristmasApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}