using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using evaluation.Models;
using evaluation.Data;

namespace evaluation.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly AppDbContext _dbContext;

        public ReportController(ILogger<ReportController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            
            var jsonData = new
            {
                Message = "This is a JSON response from the Index action.",
                Data = new { Value1 = 123, Value2 = "abc" }
            };

    
            return Json(jsonData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
