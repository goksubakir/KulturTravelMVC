using System.Collections.Generic;
using System.Web.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HotelService _hotelService;

        public ReservationController()
        {
            _hotelService = HotelService.Instance;
        }

        // Rezervasyon oluşturma sayfası
        public ActionResult Create()
        {
            // Check if user is logged in
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "Rezervasyon yapmak için lütfen giriş yapın.";
                return RedirectToAction("Login", "Auth");
            }

            // Get reservation from temp data
            var reservationJson = TempData["Reservation"]?.ToString();
            if (string.IsNullOrEmpty(reservationJson))
            {
                return RedirectToAction("Search", "Hotel");
            }

            var reservation = Newtonsoft.Json.JsonConvert.DeserializeObject<Reservation>(reservationJson);
            if (reservation == null)
            {
                return RedirectToAction("Search", "Hotel");
            }

            // Get user info from localStorage (will be handled by JavaScript)
            ViewBag.Reservation = reservation;
            return View(reservation);
        }

        // Rezervasyon kaydetme
        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Auth");
            }

            // Get user info from session
            reservation.UserEmail = GetUserEmail();
            reservation.UserName = GetUserName();
            
            var createdReservation = _hotelService.CreateReservation(reservation);
            
            TempData["ReservationId"] = createdReservation.Id;
            return RedirectToAction("Payment", "Payment");
        }

        // Kullanıcının rezervasyonları
        public ActionResult MyReservations()
        {
            // Check localStorage via JavaScript - if not logged in, redirect
            // For now, return empty list - database bağlanınca doldurulacak
            var reservations = new List<Reservation>();
            
            // Database bağlanınca bu kısım aktif olacak:
            // if (!IsUserLoggedIn())
            // {
            //     return RedirectToAction("Login", "Auth");
            // }
            // var userEmail = GetUserEmail();
            // var reservations = _hotelService.GetUserReservations(userEmail);
            
            return View(reservations);
        }

        private bool IsUserLoggedIn()
        {
            // Check session or cookie
            return Session["UserEmail"] != null;
        }

        private string GetUserEmail()
        {
            return Session["UserEmail"]?.ToString() ?? string.Empty;
        }

        private string GetUserName()
        {
            return Session["UserName"]?.ToString() ?? string.Empty;
        }
    }
}
