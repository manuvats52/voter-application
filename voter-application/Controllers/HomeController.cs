using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using voter_application.Data;
using voter_application.Models;

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

        [HttpPost]
        public IActionResult Login(string emailOrMobile, string password)
        {
            // Retrieve user from the database based on email/mobile
            var user = _dbContext.Users.FirstOrDefault(u => u.EmailOrMobile == emailOrMobile);

            // Check if user exists and password matches
            if (user != null && VerifyPassword(password, user.Password))
            {
                // Authentication successful, redirect user to dashboard or home page
                return RedirectToAction("SearchVoter", "Home");
            }

            // Authentication failed, return to login page with error message
            TempData["LoginErrorMessage"] = "Invalid email/mobile or password";
            return RedirectToAction("Login");
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // Implement your password verification logic here, e.g., using hashing algorithms like bcrypt
            // For demonstration purposes, we'll just compare plaintext passwords
            return enteredPassword == storedPasswordHash;
        }
        public IActionResult ForgotPassword()
        {
            return View("forgot_page");
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
        public IActionResult SearchVoter()
        {
            // Fetch states
            var states = _dbContext.States.ToList();
            ViewBag.States = new SelectList(states, "Id", "Name");

            // Initialize empty lists for cities and constituencies
            ViewBag.Cities = new SelectList(new List<City>(), "Id", "Name");
            ViewBag.Constituencies = new SelectList(new List<Constituency>(), "Id", "Name");

            return View("search_voter");
        }

        [HttpGet]
        public IActionResult GetCities(int stateId)
        {
            var cities = _dbContext.Cities.Where(c => c.StateId == stateId).ToList();
            return Json(new SelectList(cities, "Id", "Name"));
        }

        [HttpGet]
        public IActionResult GetConstituencies(int cityId)
        {
            var constituencies = _dbContext.Constituencies.Where(con => con.CityId == cityId).ToList();
            return Json(new SelectList(constituencies, "Id", "Name"));
        }
    }
}