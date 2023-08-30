using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using evaluation.Models;
using evaluation.Data;

namespace evaluation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly AppDbContext _dbContext; // Add this field

        public RegisterController(ILogger<RegisterController> logger, AppDbContext dbContext) // Add AppDbContext parameter
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.CurrentPage = "Register";
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();

                ViewBag.Message = "Registration successful!";
                return View();
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
