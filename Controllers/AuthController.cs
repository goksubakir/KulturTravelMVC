using Microsoft.AspNetCore.Mvc;

namespace KulturTravelMVC.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Signup()
    {
        return View();
    }
}

