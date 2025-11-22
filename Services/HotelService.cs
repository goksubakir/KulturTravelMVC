using KulturTravelMVC.Models;

namespace KulturTravelMVC.Services;

public class HotelService
{
    private static List<Hotel> _hotels = new()
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
            Images = new List<string> { "/images/1.png", "/images/2.png" },
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
            Images = new List<string> { "/images/3.png", "/images/4.png" },
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
            Images = new List<string> { "/images/5.png", "/images/6.png" },
            Rooms = new List<Room>
            {
                new Room { Id = 6, HotelId = 3, Type = "Sea View", MaxGuests = 2, PricePerNight = 3200, Description = "Deniz manzaralı oda", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon" } },
                new Room { Id = 7, HotelId = 3, Type = "Family Room", MaxGuests = 4, PricePerNight = 4500, Description = "Aile odası", Amenities = new List<string> { "WiFi", "TV", "Klima", "Balkon", "Jakuzi" } }
            },
            AverageRating = 4.6,
            TotalRatings = 200
        }
    };

    private static List<Reservation> _reservations = new();
    private static List<Rating> _ratings = new();
    private static int _nextReservationId = 1;
    private static int _nextRatingId = 1;

    public List<Hotel> GetAllHotels()
    {
        return _hotels;
    }

    public Hotel? GetHotelById(int id)
    {
        return _hotels.FirstOrDefault(h => h.Id == id);
    }

    public List<Hotel> SearchHotels(SearchViewModel search)
    {
        var hotels = _hotels.AsQueryable();

        if (!string.IsNullOrEmpty(search.Country))
            hotels = hotels.Where(h => h.Country.Contains(search.Country, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(search.City))
            hotels = hotels.Where(h => h.City.Contains(search.City, StringComparison.OrdinalIgnoreCase));

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

    public List<string> GetCities(string? country = null)
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

    public Reservation? GetReservationById(int id)
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
}

