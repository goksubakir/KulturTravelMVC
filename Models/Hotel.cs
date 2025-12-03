namespace KulturTravelMVC.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public int StarRating { get; set; }
    public List<string> Images { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();
    public double AverageRating { get; set; }
    public int TotalRatings { get; set; }
}

public class Room
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string Type { get; set; } = string.Empty; // Single, Double, Suite, etc.
    public int MaxGuests { get; set; }
    public decimal PricePerNight { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<string> Amenities { get; set; } = new();
}


