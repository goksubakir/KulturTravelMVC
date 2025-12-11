using System.Web.Mvc;
using KulturTravelMVC.Models;

namespace KulturTravelMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Error()
        {
            var requestId = System.Guid.NewGuid().ToString();
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
