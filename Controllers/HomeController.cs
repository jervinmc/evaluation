using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using evaluation.Models;
using Microsoft.EntityFrameworkCore;
using evaluation.Data;

namespace evaluation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentPage = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Password == model.Password);
                if (user != null)
                {
                    Console.WriteLine("logged in");
                    ViewBag.Message = "Succesfully Logged In";
                    return RedirectToPage("/Dashboard");

                }
                Console.WriteLine("No account");
                ViewBag.Message = "Invalid Username and Password!";
            }
 
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
