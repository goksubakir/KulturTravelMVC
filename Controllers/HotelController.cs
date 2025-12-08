using System.Linq;
using System.Web.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = HotelService.Instance;
        }

        // Otel arama sayfası
        public ActionResult Search()
        {
            ViewBag.Countries = _hotelService.GetCountries();
            ViewBag.TotalHotels = _hotelService.GetAllHotels().Count;
            return View(new SearchViewModel());
        }

        // Şehirleri getir (AJAX için)
        [HttpGet]
        public JsonResult GetCities(string country)
        {
            var cities = _hotelService.GetCities(country);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        // Otel listesi - Tüm otelleri göster
        public ActionResult List()
        {
            var hotels = _hotelService.GetAllHotels();
            ViewBag.Search = new SearchViewModel();
            return View(hotels);
        }

        // Otel listesi - Arama ile
        [HttpPost]
        public ActionResult List(SearchViewModel search)
        {
            var hotels = _hotelService.SearchHotels(search);
            ViewBag.Search = search;
            return View(hotels);
        }

        // Otel detay sayfası
        public ActionResult Details(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            // Get ratings for this hotel
            var ratings = _hotelService.GetHotelRatings(id);
            ViewBag.Ratings = ratings;

            return View(hotel);
        }

        // Oda seçimi
        [HttpPost]
        public ActionResult SelectRoom(int hotelId, int roomId, System.DateTime checkIn, System.DateTime checkOut, int guests, int adultGuests = 1, int childGuests = 0)
        {
            var hotel = _hotelService.GetHotelById(hotelId);
            if (hotel == null)
            {
                return HttpNotFound();
            }

            Room room = null;
            if (hotel.Rooms != null)
            {
                foreach (var r in hotel.Rooms)
                {
                    if (r.Id == roomId)
                    {
                        room = r;
                        break;
                    }
                }
            }
            if (room == null)
            {
                return HttpNotFound();
            }

            var nights = (checkOut - checkIn).Days;
            if (nights <= 0)
            {
                return RedirectToAction("Details", new { id = hotelId });
            }

            // Fiyat hesaplama: yetişkin tam, çocuk yarım fiyat
            var perNightPrice = (adultGuests * room.PricePerNight) + (childGuests * (room.PricePerNight * 0.5m));
            var totalPrice = perNightPrice * nights;

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
            TempData["Reservation"] = Newtonsoft.Json.JsonConvert.SerializeObject(reservation);

            return RedirectToAction("Create", "Reservation");
        }
    }
}
