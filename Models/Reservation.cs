using System;

namespace KulturTravelMVC.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Pending, Confirmed, Cancelled
        public DateTime CreatedAt { get; set; }

        public Reservation()
        {
            Status = "Pending";
            CreatedAt = DateTime.Now;
        }
    }
}


