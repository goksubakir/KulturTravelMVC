using Microsoft.AspNetCore.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers;

public class ReservationController : Controller
{
    private readonly HotelService _hotelService;
    private readonly ILogger<ReservationController> _logger;

    public ReservationController(HotelService hotelService, ILogger<ReservationController> logger)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    // Rezervasyon oluşturma sayfası
    public IActionResult Create()
    {
        // Check if user is logged in
        if (!IsUserLoggedIn())
        {
            TempData["Message"] = "Rezervasyon yapmak için lütfen giriş yapın.";
            return RedirectToAction("Login", "Auth");
        }

        // Get reservation from temp data
        var reservationJson = TempData["Reservation"]?.ToString();
        if (string.IsNullOrEmpty(reservationJson))
        {
            return RedirectToAction("Search", "Hotel");
        }

        var reservation = System.Text.Json.JsonSerializer.Deserialize<Reservation>(reservationJson);
        if (reservation == null)
        {
            return RedirectToAction("Search", "Hotel");
        }

        // Get user info from localStorage (will be handled by JavaScript)
        ViewBag.Reservation = reservation;
        return View(reservation);
    }

    // Rezervasyon kaydetme
    [HttpPost]
    public IActionResult Create(Reservation reservation)
    {
        if (!IsUserLoggedIn())
        {
            return RedirectToAction("Login", "Auth");
        }

        // Get user info from session
        reservation.UserEmail = GetUserEmail();
        reservation.UserName = GetUserName();
        
        var createdReservation = _hotelService.CreateReservation(reservation);
        
        TempData["ReservationId"] = createdReservation.Id;
        return RedirectToAction("Payment", "Payment");
    }

    // Kullanıcının rezervasyonları
    public IActionResult MyReservations()
    {
        if (!IsUserLoggedIn())
        {
            return RedirectToAction("Login", "Auth");
        }

        // Get user email from session (handled by JS)
        var userEmail = GetUserEmail();
        var reservations = _hotelService.GetUserReservations(userEmail);
        
        return View(reservations);
    }

    private bool IsUserLoggedIn()
    {
        // Check session or cookie
        return HttpContext.Session.GetString("UserEmail") != null;
    }

    private string GetUserEmail()
    {
        return HttpContext.Session.GetString("UserEmail") ?? string.Empty;
    }

    private string GetUserName()
    {
        return HttpContext.Session.GetString("UserName") ?? string.Empty;
    }
}

