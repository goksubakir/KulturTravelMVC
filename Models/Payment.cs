using System;

namespace KulturTravelMVC.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // Pending, Completed, Failed

        public Payment()
        {
            PaymentMethod = "Credit Card";
            PaymentDate = DateTime.Now;
            Status = "Pending";
        }
    }
}


