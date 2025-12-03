using Microsoft.AspNetCore.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers;

public class RatingController : Controller
{
    private readonly HotelService _hotelService;
    private readonly ILogger<RatingController> _logger;

    public RatingController(HotelService hotelService, ILogger<RatingController> logger)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    // Yıldız verme
    [HttpPost]
    public IActionResult AddRating(int hotelId, int stars, string? comment)
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


