using ChristmasApplication.Web.Models;
using System.Linq;
using System.Web.Mvc;
using ChristmasApplicationMongoDB = ChristmasApplication.Classes.MongoDB;

namespace ChristmasApplication.Web.Controllers
{
    public class ToysController : Controller
    {
        // GET: Toys
        public ActionResult IndexToys()
        {
            if (Session["ScreenName"] != null)
            {
                ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
                var toys = db.GetAllToys();
                Toys modelToys = new Toys();
                modelToys.ToysList = toys.ToList();
                return View(modelToys);
            }
            else
                return RedirectToAction("Index", "Home", null);
        }
    }
}