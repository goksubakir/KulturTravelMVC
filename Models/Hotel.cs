using System.Collections.Generic;

namespace KulturTravelMVC.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int StarRating { get; set; }
        public List<string> Images { get; set; }
        public List<Room> Rooms { get; set; }
        public double AverageRating { get; set; }
        public int TotalRatings { get; set; }

        public Hotel()
        {
            Images = new List<string>();
            Rooms = new List<Room>();
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Type { get; set; } // Single, Double, Suite, etc.
        public int MaxGuests { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public List<string> Amenities { get; set; }

        public Room()
        {
            Amenities = new List<string>();
        }
    }
}


