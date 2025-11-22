using Microsoft.AspNetCore.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers;

public class AdminController : Controller
{
    private readonly HotelService _hotelService;
    private readonly ILogger<AdminController> _logger;
    private static List<User> _users = new();

    public AdminController(HotelService hotelService, ILogger<AdminController> logger)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    // Admin giriş sayfası
    public IActionResult Login()
    {
        return View();
    }

    // Admin giriş işlemi
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        // Basit admin kontrolü (gerçek uygulamada veritabanından kontrol edilmeli)
        if (email == "admin@kultur.com" && password == "admin123")
        {
            HttpContext.Session.SetString("AdminEmail", email);
            HttpContext.Session.SetString("AdminName", "Admin");
            return RedirectToAction("Dashboard");
        }

        ViewBag.Error = "Geçersiz admin bilgileri!";
        return View();
    }

    // Admin çıkış
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    // Admin dashboard
    public IActionResult Dashboard()
    {
        if (!IsAdminLoggedIn())
        {
            return RedirectToAction("Login");
        }

        var hotels = _hotelService.GetAllHotels();
        return View(hotels);
    }

    // Otel düzenleme sayfası
    public IActionResult EditHotel(int id)
    {
        if (!IsAdminLoggedIn())
        {
            return RedirectToAction("Login");
        }

        var hotel = _hotelService.GetHotelById(id);
        if (hotel == null)
        {
            return NotFound();
        }

        return View(hotel);
    }

    // Otel güncelleme
    [HttpPost]
    public IActionResult UpdateHotel(Hotel hotel)
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
    public IActionResult DeleteHotel(int id)
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
    public IActionResult Users()
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
    public IActionResult DeleteUser(int id)
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
        return HttpContext.Session.GetString("AdminEmail") != null;
    }
}


