using System.Web.Mvc;
using System.Web.SessionState;

namespace KulturTravelMVC.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Check localStorage via JavaScript, but also set session
            // This will be handled by JavaScript on client side
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SetSession(string email, string name)
        {
            Session["UserEmail"] = email;
            Session["UserName"] = name;
            return Json(new { success = true });
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
