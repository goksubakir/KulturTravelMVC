using Microsoft.AspNetCore.Mvc;
using KulturTravelMVC.Models;
using KulturTravelMVC.Services;

namespace KulturTravelMVC.Controllers;

public class PaymentController : Controller
{
    private readonly HotelService _hotelService;
    private readonly ILogger<PaymentController> _logger;
    private static List<Payment> _payments = new();
    private static int _nextPaymentId = 1;

    public PaymentController(HotelService hotelService, ILogger<PaymentController> logger)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    // Ödeme sayfası
    public IActionResult Payment()
    {
        // Login kontrolü
        if (!IsUserLoggedIn())
        {
            TempData["Message"] = "Ödeme yapmak için lütfen giriş yapın.";
            return RedirectToAction("Login", "Auth");
        }

        // Get reservation ID from temp data
        var reservationId = TempData["ReservationId"]?.ToString();
        if (string.IsNullOrEmpty(reservationId))
        {
            return RedirectToAction("Search", "Hotel");
        }

        var reservation = _hotelService.GetReservationById(Convert.ToInt32(reservationId));
        if (reservation == null)
        {
            return RedirectToAction("Search", "Hotel");
        }

        ViewBag.Reservation = reservation;
        return View(new Payment { ReservationId = reservation.Id, Amount = reservation.TotalPrice });
    }

    // Ödeme işlemi
    [HttpPost]
    public IActionResult ProcessPayment(Payment payment)
    {
        if (!IsUserLoggedIn())
        {
            return RedirectToAction("Login", "Auth");
        }

        // Validate payment (simplified - in real app, validate card details)
        if (string.IsNullOrEmpty(payment.CardNumber) || 
            string.IsNullOrEmpty(payment.CardHolderName) ||
            string.IsNullOrEmpty(payment.ExpiryDate) ||
            string.IsNullOrEmpty(payment.CVV))
        {
            ModelState.AddModelError("", "Lütfen tüm ödeme bilgilerini doldurun.");
            var reservation = _hotelService.GetReservationById(payment.ReservationId);
            ViewBag.Reservation = reservation;
            return View("Payment", payment);
        }

        // Process payment (simplified - in real app, integrate with payment gateway)
        payment.Id = _nextPaymentId++;
        payment.PaymentDate = DateTime.Now;
        payment.Status = "Completed";
        _payments.Add(payment);

        // Update reservation status
        var reservationToUpdate = _hotelService.GetReservationById(payment.ReservationId);
        if (reservationToUpdate != null)
        {
            reservationToUpdate.Status = "Confirmed";
        }

        TempData["PaymentSuccess"] = true;
        TempData["PaymentId"] = payment.Id;
        return RedirectToAction("Success");
    }

    // Ödeme başarılı sayfası
    public IActionResult Success()
    {
        if (TempData["PaymentSuccess"] == null)
        {
            return RedirectToAction("Search", "Hotel");
        }

        var paymentId = TempData["PaymentId"]?.ToString();
        var payment = _payments.FirstOrDefault(p => p.Id == Convert.ToInt32(paymentId));
        
        return View(payment);
    }

    private bool IsUserLoggedIn()
    {
        return HttpContext.Session.GetString("UserEmail") != null;
    }
}

