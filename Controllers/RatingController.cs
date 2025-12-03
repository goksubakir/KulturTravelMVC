using System.Web.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly HotelService _hotelService;

        public RatingController()
        {
            _hotelService = HotelService.Instance;
        }

        // Yıldız verme
        [HttpPost]
        public JsonResult AddRating(int hotelId, int stars, string comment)
        {
            if (!IsUserLoggedIn())
            {
                return Json(new { success = false, message = "Yıldız vermek için lütfen giriş yapın." });
            }

            var rating = new Rating
            {
                HotelId = hotelId,
                UserEmail = GetUserEmail(),
                UserName = GetUserName(),
                Stars = stars,
                Comment = comment
            };

            _hotelService.AddRating(rating);

            return Json(new { success = true, message = "Değerlendirmeniz kaydedildi." });
        }

        private bool IsUserLoggedIn()
        {
            return Session["UserEmail"] != null;
        }

        private string GetUserEmail()
        {
            return Session["UserEmail"]?.ToString() ?? string.Empty;
        }

        private string GetUserName()
        {
            return Session["UserName"]?.ToString() ?? string.Empty;
        }
    }
}
