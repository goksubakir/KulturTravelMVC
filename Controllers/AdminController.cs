using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly HotelService _hotelService;
        private static List<User> _users = new List<User>();

        public AdminController()
        {
            _hotelService = HotelService.Instance;
        }

        // Admin giriş sayfası
        public ActionResult Login()
        {
            return View();
        }

        // Admin giriş işlemi
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Basit admin kontrolü (gerçek uygulamada veritabanından kontrol edilmeli)
            if (email == "admin@kultur.com" && password == "admin123")
            {
                Session["AdminEmail"] = email;
                Session["AdminName"] = "Admin";
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Geçersiz admin bilgileri!";
            return View();
        }

        // Admin çıkış
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        // Admin dashboard
        public ActionResult Dashboard()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            var hotels = _hotelService.GetAllHotels();
            return View(hotels);
        }

        // Otel düzenleme sayfası
        public ActionResult EditHotel(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            return View(hotel);
        }

        // Otel güncelleme
        [HttpPost]
        public ActionResult UpdateHotel(Hotel hotel)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            _hotelService.UpdateHotel(hotel);
            TempData["Message"] = "Otel başarıyla güncellendi.";
            return RedirectToAction("Dashboard");
        }

        // Otel silme
        [HttpPost]
        public ActionResult DeleteHotel(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            _hotelService.DeleteHotel(id);
            TempData["Message"] = "Otel başarıyla silindi.";
            return RedirectToAction("Dashboard");
        }

        // Kullanıcı listesi
        public ActionResult Users()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            // Get users from localStorage (will be handled by JS in real app)
            // For now, return empty list
            return View(new List<User>());
        }

        // Kullanıcı silme
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                TempData["Message"] = "Kullanıcı başarıyla silindi.";
            }

            return RedirectToAction("Users");
        }

        private bool IsAdminLoggedIn()
        {
            return Session["AdminEmail"] != null;
        }
    }
}
