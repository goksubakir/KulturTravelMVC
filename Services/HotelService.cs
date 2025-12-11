using System;
using System.Collections.Generic;
using System.Linq;
using KulturTravelMVC.Models;

namespace KulturTravelMVC.Services
{
    public class HotelService
    {
        private static HotelService _instance;
        private static readonly object _lock = new object();

        public static HotelService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new HotelService();
                        }
                    }
                }
                return _instance;
            }
        }

        private HotelService()
        {
        }

        private static List<Hotel> _hotels = new List<Hotel>
    {
        new Hotel
        {
            Id = 1,
            Name = "Grand Istanbul Hotel",
            Country = "Türkiye",
            City = "İstanbul",
            Address = "Sultanahmet, İstanbul",
            Description = "Tarihi yarımadada lüks konaklama imkanı sunan 5 yıldızlı otel.",
            PricePerNight = 2500,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel1.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 1, HotelId = 1, Type = "Single", MaxGuests = 1, PricePerNight = 2000, Description = "Tek kişilik oda", Amenities = new List<string> { "WiFi", "TV", "Klima" } },
                new Room { Id = 2, HotelId = 1, Type = "Double", MaxGuests = 2, PricePerNight = 2500, Description = "Çift kişilik oda", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon" } },
                new Room { Id = 3, HotelId = 1, Type = "Suite", MaxGuests = 4, PricePerNight = 5000, Description = "Lüks suit", Amenities = new List<string> { "WiFi", "TV", "Klima", "Jakuzi", "Balkon" } }
            },
            AverageRating = 4.5,
            TotalRatings = 120
        },
        new Hotel
        {
            Id = 2,
            Name = "Cappadocia Cave Hotel",
            Country = "Türkiye",
            City = "Nevşehir",
            Address = "Göreme, Nevşehir",
            Description = "Peri bacaları manzaralı mağara oteli.",
            PricePerNight = 1800,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel2.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 4, HotelId = 2, Type = "Cave Room", MaxGuests = 2, PricePerNight = 1800, Description = "Geleneksel mağara odası", Amenities = new List<string> { "WiFi", "TV", "Şömine" } },
                new Room { Id = 5, HotelId = 2, Type = "Deluxe Cave", MaxGuests = 3, PricePerNight = 2500, Description = "Geniş mağara odası", Amenities = new List<string> { "WiFi", "TV", "Şömine", "Balkon" } }
            },
            AverageRating = 4.8,
            TotalRatings = 85
        },
        new Hotel
        {
            Id = 3,
            Name = "Antalya Beach Resort",
            Country = "Türkiye",
            City = "Antalya",
            Address = "Lara, Antalya",
            Description = "Denize sıfır 5 yıldızlı tatil köyü.",
            PricePerNight = 3200,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel3.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 6, HotelId = 3, Type = "Sea View", MaxGuests = 2, PricePerNight = 3200, Description = "Deniz manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon" } },
                new Room { Id = 7, HotelId = 3, Type = "Family Room", MaxGuests = 4, PricePerNight = 4500, Description = "Aile odası", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon", "Jakuzi" } }
            },
            AverageRating = 4.6,
            TotalRatings = 200
        },
        // Türkiye - 3 otel daha (Toplam 6)
        new Hotel
        {
            Id = 4,
            Name = "Bodrum Marina Hotel",
            Country = "Türkiye",
            City = "Bodrum",
            Address = "Marina, Bodrum",
            Description = "Marina manzaralı lüks butik otel, mavi yolculuk deneyimi.",
            PricePerNight = 2800,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel4.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 8, HotelId = 4, Type = "Marina View", MaxGuests = 2, PricePerNight = 2800, Description = "Marina manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon", "Minibar" } },
                new Room { Id = 9, HotelId = 4, Type = "Deluxe Suite", MaxGuests = 3, PricePerNight = 4000, Description = "Deniz manzaralı suit", Amenities = new List<string> { "WiFi", "TV", "Klima", "Jakuzi", "Balkon" } }
            },
            AverageRating = 4.7,
            TotalRatings = 150
        },
        new Hotel
        {
            Id = 5,
            Name = "Kapadokya Luxury Suites",
            Country = "Türkiye",
            City = "Ürgüp",
            Address = "Ürgüp, Nevşehir",
            Description = "Göreme'nin en lüks mağara oteli, sıcak hava balonu manzarası.",
            PricePerNight = 3500,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel5.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 10, HotelId = 5, Type = "Cave Suite", MaxGuests = 2, PricePerNight = 3500, Description = "Peri bacası manzaralı mağara suit", Amenities = new List<string> { "WiFi", "TV", "Şömine", "Jakuzi", "Balkon" } },
                new Room { Id = 11, HotelId = 5, Type = "Royal Cave", MaxGuests = 4, PricePerNight = 5500, Description = "Premium mağara odası", Amenities = new List<string> { "WiFi", "TV", "Şömine", "Jakuzi", "Private Terrace" } }
            },
            AverageRating = 4.9,
            TotalRatings = 95
        },
        new Hotel
        {
            Id = 6,
            Name = "Pamukkale Thermal Hotel",
            Country = "Türkiye",
            City = "Pamukkale",
            Address = "Pamukkale, Denizli",
            Description = "Termal havuzlu, traverten manzaralı wellness oteli.",
            PricePerNight = 2200,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel6.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 12, HotelId = 6, Type = "Travertine View", MaxGuests = 2, PricePerNight = 2200, Description = "Traverten manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon" } },
                new Room { Id = 13, HotelId = 6, Type = "Thermal Suite", MaxGuests = 3, PricePerNight = 3500, Description = "Özel termal havuzlu suit", Amenities = new List<string> { "WiFi", "TV", "Private Thermal Pool", "Balkon" } }
            },
            AverageRating = 4.4,
            TotalRatings = 180
        },
        // Hollanda - 3 otel
        new Hotel
        {
            Id = 7,
            Name = "Amsterdam Canal Boutique Hotel",
            Country = "Hollanda",
            City = "Amsterdam",
            Address = "Herengracht, Amsterdam",
            Description = "Kanal manzaralı tarihi butik otel, şehir merkezinde.",
            PricePerNight = 4500,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel7.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 14, HotelId = 7, Type = "Canal View", MaxGuests = 2, PricePerNight = 4500, Description = "Kanal manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "Heating", "Minibar" } },
                new Room { Id = 15, HotelId = 7, Type = "Deluxe Suite", MaxGuests = 3, PricePerNight = 6500, Description = "Geniş kanal manzaralı suit", Amenities = new List<string> { "WiFi", "TV", "Heating", "Balcony", "Minibar" } }
            },
            AverageRating = 4.6,
            TotalRatings = 230
        },
        new Hotel
        {
            Id = 8,
            Name = "Rotterdam Modern Hotel",
            Country = "Hollanda",
            City = "Rotterdam",
            Address = "Witte de Withstraat, Rotterdam",
            Description = "Modern mimari tasarımlı, trend semtinde konumlanmış otel.",
            PricePerNight = 3200,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel8.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 16, HotelId = 8, Type = "Standard Room", MaxGuests = 2, PricePerNight = 3200, Description = "Modern tasarım oda", Amenities = new List<string> { "WiFi", "TV", "Heating", "Minibar" } },
                new Room { Id = 17, HotelId = 8, Type = "City View Suite", MaxGuests = 3, PricePerNight = 4800, Description = "Şehir manzaralı geniş suit", Amenities = new List<string> { "WiFi", "TV", "Heating", "Balcony", "Coffee Machine" } }
            },
            AverageRating = 4.5,
            TotalRatings = 175
        },
        new Hotel
        {
            Id = 9,
            Name = "Haarlem Historic Inn",
            Country = "Hollanda",
            City = "Haarlem",
            Address = "Grote Markt, Haarlem",
            Description = "Tarihi şehir merkezinde, Ortaçağ mimarisinde butik otel.",
            PricePerNight = 2800,
            StarRating = 3,
            Images = new List<string> { "/Content/images/otel9.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 18, HotelId = 9, Type = "Historic Room", MaxGuests = 2, PricePerNight = 2800, Description = "Tarihi atmosferde oda", Amenities = new List<string> { "WiFi", "TV", "Heating" } },
                new Room { Id = 19, HotelId = 9, Type = "Market Square View", MaxGuests = 2, PricePerNight = 3800, Description = "Pazar meydanı manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "Heating", "Balcony" } }
            },
            AverageRating = 4.3,
            TotalRatings = 120
        },
        // İtalya - 3 otel
        new Hotel
        {
            Id = 10,
            Name = "Roma Colosseum Palace",
            Country = "İtalya",
            City = "Roma",
            Address = "Via dei Fori Imperiali, Roma",
            Description = "Kolezyum'a yürüme mesafesinde lüks 5 yıldızlı otel.",
            PricePerNight = 5200,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel10.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 20, HotelId = 10, Type = "Colosseum View", MaxGuests = 2, PricePerNight = 5200, Description = "Kolezyum manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "AC", "Minibar", "Balcony" } },
                new Room { Id = 21, HotelId = 10, Type = "Royal Suite", MaxGuests = 4, PricePerNight = 8500, Description = "Premium kolezyum manzaralı suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Jacuzzi", "Private Terrace" } }
            },
            AverageRating = 4.8,
            TotalRatings = 320
        },
        new Hotel
        {
            Id = 11,
            Name = "Venedik Canal Resort",
            Country = "İtalya",
            City = "Venedik",
            Address = "Canal Grande, Venedik",
            Description = "Grand Canal üzerinde, gondol manzaralı romantik otel.",
            PricePerNight = 6800,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel11.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 22, HotelId = 11, Type = "Canal Grande View", MaxGuests = 2, PricePerNight = 6800, Description = "Grand Canal manzaralı romantik oda", Amenities = new List<string> { "WiFi", "TV", "AC", "Minibar", "Balcony" } },
                new Room { Id = 23, HotelId = 11, Type = "Gondola Suite", MaxGuests = 3, PricePerNight = 9800, Description = "Gondol geçişlerini izleyebileceğiniz suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Jacuzzi", "Private Balcony" } }
            },
            AverageRating = 4.9,
            TotalRatings = 280
        },
        new Hotel
        {
            Id = 12,
            Name = "Floransa Renaissance Hotel",
            Country = "İtalya",
            City = "Floransa",
            Address = "Piazza del Duomo, Floransa",
            Description = "Duomo manzaralı, Rönesans döneminden ilham alan butik otel.",
            PricePerNight = 4800,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel12.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 24, HotelId = 12, Type = "Duomo View", MaxGuests = 2, PricePerNight = 4800, Description = "Duomo katedrali manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "AC", "Minibar", "Balcony" } },
                new Room { Id = 25, HotelId = 12, Type = "Renaissance Suite", MaxGuests = 3, PricePerNight = 7200, Description = "Rönesans dekorlu lüks suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Balcony", "Antique Furniture" } }
            },
            AverageRating = 4.7,
            TotalRatings = 195
        },
        // Dubai - 3 otel
        new Hotel
        {
            Id = 13,
            Name = "Burj Al Arab Luxury",
            Country = "Dubai",
            City = "Dubai",
            Address = "Jumeirah Beach, Dubai",
            Description = "7 yıldızlı efsane otel, muhteşem körfez manzarası.",
            PricePerNight = 15000,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel13.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 26, HotelId = 13, Type = "Deluxe Suite", MaxGuests = 2, PricePerNight = 15000, Description = "Geniş suit, körfez manzarası", Amenities = new List<string> { "WiFi", "TV", "AC", "Butler Service", "Private Lift" } },
                new Room { Id = 27, HotelId = 13, Type = "Royal Suite", MaxGuests = 4, PricePerNight = 25000, Description = "Premium suit, 360 derece manzara", Amenities = new List<string> { "WiFi", "TV", "AC", "Private Butler", "Helipad Access", "Jacuzzi" } }
            },
            AverageRating = 4.9,
            TotalRatings = 450
        },
        new Hotel
        {
            Id = 14,
            Name = "Dubai Marina Tower",
            Country = "Dubai",
            City = "Dubai",
            Address = "Dubai Marina, Dubai",
            Description = "Marina bölgesinde yüksek katlı modern otel, gökdelen manzarası.",
            PricePerNight = 5800,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel14.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 28, HotelId = 14, Type = "Marina View", MaxGuests = 2, PricePerNight = 5800, Description = "Marina ve şehir manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "AC", "Minibar", "Balcony" } },
                new Room { Id = 29, HotelId = 14, Type = "Sky Suite", MaxGuests = 4, PricePerNight = 9500, Description = "Yüksek katlı premium suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Private Balcony", "Jacuzzi", "City View" } }
            },
            AverageRating = 4.6,
            TotalRatings = 380
        },
        new Hotel
        {
            Id = 15,
            Name = "Palm Jumeirah Beach Resort",
            Country = "Dubai",
            City = "Dubai",
            Address = "Palm Jumeirah, Dubai",
            Description = "Palmiye adasında, özel plajlı lüks tatil köyü.",
            PricePerNight = 7200,
            StarRating = 5,
            Images = new List<string> { "/Content/images/otel15.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 30, HotelId = 15, Type = "Beach View", MaxGuests = 2, PricePerNight = 7200, Description = "Deniz ve palmiye manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "AC", "Minibar", "Balcony", "Beach Access" } },
                new Room { Id = 31, HotelId = 15, Type = "Villa Suite", MaxGuests = 4, PricePerNight = 12000, Description = "Özel villa tarzı suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Private Pool", "Beach Access", "Butler Service" } }
            },
            AverageRating = 4.8,
            TotalRatings = 420
        },
        // Japonya - 3 otel
        new Hotel
        {
            Id = 16,
            Name = "Tokyo Sakura Hotel",
            Country = "Japonya",
            City = "Tokyo",
            Address = "Shibuya, Tokyo",
            Description = "Shibuya'da modern Japon estetiği ile tasarlanmış otel.",
            PricePerNight = 6200,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel16.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 32, HotelId = 16, Type = "City View", MaxGuests = 2, PricePerNight = 6200, Description = "Tokyo manzaralı modern oda", Amenities = new List<string> { "WiFi", "TV", "AC", "Minibar", "Tatami Area" } },
                new Room { Id = 33, HotelId = 16, Type = "Sakura Suite", MaxGuests = 3, PricePerNight = 9800, Description = "Geleneksel Japon tasarımı suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Tatami Room", "Tea Ceremony Space", "Balcony" } }
            },
            AverageRating = 4.7,
            TotalRatings = 290
        },
        new Hotel
        {
            Id = 17,
            Name = "Kyoto Ryokan Inn",
            Country = "Japonya",
            City = "Kyoto",
            Address = "Gion District, Kyoto",
            Description = "Geleneksel ryokan oteli, Gion bölgesinde, geishaların geçtiği sokaklarda.",
            PricePerNight = 8500,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel17.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 34, HotelId = 17, Type = "Traditional Room", MaxGuests = 2, PricePerNight = 8500, Description = "Geleneksel tatami odası", Amenities = new List<string> { "WiFi", "TV", "AC", "Futon Beds", "Private Onsen" } },
                new Room { Id = 35, HotelId = 17, Type = "Garden View Suite", MaxGuests = 3, PricePerNight = 12500, Description = "Japon bahçesi manzaralı premium suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Private Garden", "Onsen", "Kaiseki Meals" } }
            },
            AverageRating = 4.9,
            TotalRatings = 180
        },
        new Hotel
        {
            Id = 18,
            Name = "Osaka Business Hotel",
            Country = "Japonya",
            City = "Osaka",
            Address = "Dotonbori, Osaka",
            Description = "Şehir merkezinde, Dotonbori manzaralı modern iş oteli.",
            PricePerNight = 4800,
            StarRating = 4,
            Images = new List<string> { "/Content/images/otel18.jpg" },
            Rooms = new List<Room>
            {
                new Room { Id = 36, HotelId = 18, Type = "Standard Business", MaxGuests = 2, PricePerNight = 4800, Description = "Modern iş odası", Amenities = new List<string> { "WiFi", "TV", "AC", "Work Desk", "Minibar" } },
                new Room { Id = 37, HotelId = 18, Type = "Dotonbori View Suite", MaxGuests = 3, PricePerNight = 7800, Description = "Neon ışıklar manzaralı suit", Amenities = new List<string> { "WiFi", "TV", "AC", "Balcony", "City View", "Work Space" } }
            },
            AverageRating = 4.5,
            TotalRatings = 320
        }
    };

        private static List<Reservation> _reservations = new List<Reservation>();
        private static List<Rating> _ratings = new List<Rating>();
    private static int _nextReservationId = 1;
    private static int _nextRatingId = 1;

    public List<Hotel> GetAllHotels()
    {
        return _hotels;
    }

        public Hotel GetHotelById(int id)
        {
            return _hotels.FirstOrDefault(h => h.Id == id);
        }

    public List<Hotel> SearchHotels(SearchViewModel search)
    {
        var hotels = _hotels.AsQueryable();

        if (!string.IsNullOrEmpty(search.Country))
            hotels = hotels.Where(h => h.Country != null && h.Country.IndexOf(search.Country, StringComparison.OrdinalIgnoreCase) >= 0);

        if (!string.IsNullOrEmpty(search.City))
            hotels = hotels.Where(h => h.City != null && h.City.IndexOf(search.City, StringComparison.OrdinalIgnoreCase) >= 0);

        if (search.MinPrice.HasValue)
            hotels = hotels.Where(h => h.PricePerNight >= search.MinPrice.Value);

        if (search.MaxPrice.HasValue)
            hotels = hotels.Where(h => h.PricePerNight <= search.MaxPrice.Value);

        if (search.StarRating.HasValue)
            hotels = hotels.Where(h => h.StarRating >= search.StarRating.Value);

        return hotels.ToList();
    }

    public List<string> GetCountries()
    {
        return _hotels.Select(h => h.Country).Distinct().OrderBy(c => c).ToList();
    }

    public List<string> GetCities(string country = "")
    {
        var hotels = _hotels.AsQueryable();
        if (!string.IsNullOrEmpty(country))
            hotels = hotels.Where(h => h.Country == country);
        
        return hotels.Select(h => h.City).Distinct().OrderBy(c => c).ToList();
    }

    public Reservation CreateReservation(Reservation reservation)
    {
        reservation.Id = _nextReservationId++;
        reservation.CreatedAt = DateTime.Now;
        _reservations.Add(reservation);
        return reservation;
    }

    public List<Reservation> GetUserReservations(string userEmail)
    {
        return _reservations.Where(r => r.UserEmail == userEmail).ToList();
    }

        public Reservation GetReservationById(int id)
        {
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

    public Rating AddRating(Rating rating)
    {
        rating.Id = _nextRatingId++;
        rating.CreatedAt = DateTime.Now;
        _ratings.Add(rating);

        // Update hotel average rating
        var hotel = GetHotelById(rating.HotelId);
        if (hotel != null)
        {
            var hotelRatings = _ratings.Where(r => r.HotelId == rating.HotelId).ToList();
            hotel.AverageRating = hotelRatings.Average(r => r.Stars);
            hotel.TotalRatings = hotelRatings.Count;
        }

        return rating;
    }

    public List<Rating> GetHotelRatings(int hotelId)
    {
        return _ratings.Where(r => r.HotelId == hotelId).OrderByDescending(r => r.CreatedAt).ToList();
    }

    public void UpdateHotel(Hotel hotel)
    {
        var existing = GetHotelById(hotel.Id);
        if (existing != null)
        {
            existing.Name = hotel.Name;
            existing.PricePerNight = hotel.PricePerNight;
            existing.Images = hotel.Images;
            existing.Description = hotel.Description;
        }
    }

    public void DeleteHotel(int id)
    {
        var hotel = GetHotelById(id);
        if (hotel != null)
            _hotels.Remove(hotel);
        }

    public void AddHotel(Hotel hotel)
    {
        // Yeni ID oluştur
        int newId = _hotels.Count > 0 ? _hotels.Max(h => h.Id) + 1 : 1;
        hotel.Id = newId;

        // Room ID'lerini güncelle
        if (hotel.Rooms != null)
        {
            int roomId = 1;
            foreach (var room in hotel.Rooms)
            {
                room.Id = roomId++;
                room.HotelId = newId;
            }
        }

        // Varsayılan değerler
        if (hotel.Images == null || hotel.Images.Count == 0)
        {
            hotel.Images = new List<string> { $"/Content/images/otel{newId}.jpg" };
        }

        if (hotel.AverageRating == 0)
        {
            hotel.AverageRating = 0;
            hotel.TotalRatings = 0;
        }

        _hotels.Add(hotel);
    }
    }
}

