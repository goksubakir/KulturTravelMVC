using System;

namespace KulturTravelMVC.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int Stars { get; set; } // 1-5
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public Rating()
        {
            CreatedAt = DateTime.Now;
        }
    }
}


