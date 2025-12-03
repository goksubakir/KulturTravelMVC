namespace KulturTravelMVC.Models;

public class SearchViewModel
{
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public int? NumberOfGuests { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public int? StarRating { get; set; }
}


