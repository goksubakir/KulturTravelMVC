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

        // Yeni otel ekleme sayfası
        [HttpGet]
        public ActionResult AddHotel()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        // Yeni otel ekleme işlemi
        [HttpPost]
        public ActionResult AddHotel(string Name, string Country, string City, string Address, string Description, 
            decimal PricePerNight, int StarRating, string Images, 
            string[] roomTypes, int[] roomMaxGuests, decimal[] roomPrices, string[] roomDescriptions, string[] roomAmenities)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login");
            }

            // Hotel objesi oluştur
            var hotel = new Hotel
            {
                Name = Name,
                Country = Country,
                City = City,
                Address = Address,
                Description = Description,
                PricePerNight = PricePerNight,
                StarRating = StarRating,
                Images = new List<string>(),
                Rooms = new List<Room>()
            };

            // Görselleri parse et
            if (!string.IsNullOrEmpty(Images))
            {
                try
                {
                    hotel.Images = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(Images) ?? new List<string>();
                }
                catch
                {
                    // JSON parse hatası durumunda boş liste
                    hotel.Images = new List<string>();
                }
            }

            // Odaları oluştur
            if (roomTypes != null && roomTypes.Length > 0)
            {
                int roomId = 1;
                for (int i = 0; i < roomTypes.Length; i++)
                {
                    if (!string.IsNullOrEmpty(roomTypes[i]))
                    {
                        var room = new Room
                        {
                            Id = roomId++,
                            HotelId = 0, // Hotel ID henüz yok, sonra set edilecek
                            Type = roomTypes[i],
                            MaxGuests = roomMaxGuests != null && i < roomMaxGuests.Length ? roomMaxGuests[i] : 2,
                            PricePerNight = roomPrices != null && i < roomPrices.Length ? roomPrices[i] : 0,
                            Description = roomDescriptions != null && i < roomDescriptions.Length ? roomDescriptions[i] : "",
                            Amenities = new List<string>()
                        };

                        // Amenities'i parse et (virgülle ayrılmış)
                        if (roomAmenities != null && i < roomAmenities.Length && !string.IsNullOrEmpty(roomAmenities[i]))
                        {
                            room.Amenities = roomAmenities[i].Split(',').Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a)).ToList();
                        }

                        hotel.Rooms.Add(room);
                    }
                }
            }

            _hotelService.AddHotel(hotel);
            TempData["Message"] = "Otel başarıyla eklendi.";
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
