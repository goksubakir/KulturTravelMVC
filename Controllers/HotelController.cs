using Microsoft.AspNetCore.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers;

public class HotelController : Controller
{
    private readonly HotelService _hotelService;
    private readonly ILogger<HotelController> _logger;

    public HotelController(HotelService hotelService, ILogger<HotelController> logger)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    // Otel arama sayfası
    public IActionResult Search()
    {
        ViewBag.Countries = _hotelService.GetCountries();
        ViewBag.TotalHotels = _hotelService.GetAllHotels().Count;
        return View(new SearchViewModel());
    }

    // Şehirleri getir (AJAX için)
    [HttpGet]
    public IActionResult GetCities(string country)
    {
        var cities = _hotelService.GetCities(country);
        return Json(cities);
    }

    // Otel listesi - Tüm otelleri göster
    public IActionResult List()
    {
        var hotels = _hotelService.GetAllHotels();
        ViewBag.Search = new SearchViewModel();
        return View(hotels);
    }

    // Otel listesi - Arama ile
    [HttpPost]
    public IActionResult List(SearchViewModel search)
    {
        var hotels = _hotelService.SearchHotels(search);
        ViewBag.Search = search;
        return View(hotels);
    }

    // Otel detay sayfası
    public IActionResult Details(int id)
    {
        var hotel = _hotelService.GetHotelById(id);
        if (hotel == null)
        {
            return NotFound();
        }

        // Get ratings for this hotel
        var ratings = _hotelService.GetHotelRatings(id);
        ViewBag.Ratings = ratings;

        return View(hotel);
    }

    // Oda seçimi
    [HttpPost]
    public IActionResult SelectRoom(int hotelId, int roomId, DateTime checkIn, DateTime checkOut, int guests)
    {
        var hotel = _hotelService.GetHotelById(hotelId);
        if (hotel == null)
        {
            return NotFound();
        }

        var room = hotel.Rooms.FirstOrDefault(r => r.Id == roomId);
        if (room == null)
        {
            return NotFound();
        }

        var nights = (checkOut - checkIn).Days;
        var totalPrice = room.PricePerNight * nights;

        var reservation = new Reservation
        {
            HotelId = hotelId,
            HotelName = hotel.Name,
            RoomId = roomId,
            RoomType = room.Type,
            CheckInDate = checkIn,
            CheckOutDate = checkOut,
            NumberOfGuests = guests,
            TotalPrice = totalPrice
        };

        // Store in session or temp data
        TempData["Reservation"] = System.Text.Json.JsonSerializer.Serialize(reservation);

        return RedirectToAction("Create", "Reservation");
    }
}


