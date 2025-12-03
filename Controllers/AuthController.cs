using Microsoft.AspNetCore.Mvc;

namespace KulturTravelMVC.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        // Check localStorage via JavaScript, but also set session
        // This will be handled by JavaScript on client side
        return View();
    }

    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SetSession(string email, string name)
    {
        HttpContext.Session.SetString("UserEmail", email);
        HttpContext.Session.SetString("UserName", name);
        return Json(new { success = true });
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}

