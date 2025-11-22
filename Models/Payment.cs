namespace KulturTravelMVC.Models;

public class Payment
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string CardHolderName { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = "Credit Card";
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Pending"; // Pending, Completed, Failed
}


