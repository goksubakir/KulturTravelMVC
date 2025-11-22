namespace KulturTravelMVC.Models;

public class Reservation
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public int RoomId { get; set; }
    public string RoomType { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}


