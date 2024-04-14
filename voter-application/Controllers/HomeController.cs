using Microsoft.AspNetCore.Mvc;
using voter_application.Models;
using voter_application.Data; // Import your DbContext namespace
using System.Diagnostics;
using voter_application.Views.Home;

namespace voter_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VoterDbContext _dbContext; // Add DbContext

        public HomeController(ILogger<HomeController> logger, VoterDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext; // Initialize DbContext
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


        [HttpPost]
        public IActionResult SignUp(users model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("login", "Home");
            }
            return View("signup_page"); // Return the sign-up page with errors if validation fails
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