using System.Web.Mvc;
using KulturTravelMVC.Models;

namespace KulturTravelMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda sayfası.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim sayfası.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Bu sayfa sadece Admin rolüne sahip kullanıcılar tarafından görüntülenebilir.";
            return View();
        }

        [Authorize(Roles = "Admin,User")]
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Hoş geldiniz!";
            return View();
        }
    }
}
