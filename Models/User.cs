using System;

namespace KulturTravelMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // User, Admin
        public DateTime CreatedAt { get; set; }

        public User()
        {
            Role = "User";
            CreatedAt = DateTime.Now;
        }
    }
}


