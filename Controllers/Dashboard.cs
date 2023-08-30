using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using evaluation.Models;
using evaluation.Data;

namespace evaluation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly AppDbContext _dbContext;

        public DashboardController(ILogger<DashboardController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Console.WriteLine("test");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
