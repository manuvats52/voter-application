using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using voter_application.Models;

namespace voter_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("login_page");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View("signup_page");
        }
        public IActionResult CancelSignup()
        {
            return RedirectToAction("Login"); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
