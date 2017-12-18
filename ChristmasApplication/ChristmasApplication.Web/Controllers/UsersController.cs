using ChristmasApplication.Classes;
using System.Web.Mvc;
using ChristmasApplicationMongoDB = ChristmasApplication.Classes.MongoDB;

namespace ChristmasApplication.Web.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Login()
        {
            if (Session["ScreenName"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home", null);
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
            var usr = db.GetUserByEmailAndPassword(user);
            if (usr != null)
            {
                Session["ScreenName"] = usr.ScreenName.ToString();
                return RedirectToAction("Index", "Home", null);
            }
            else
                ModelState.AddModelError("", "Username o Password errati");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}