using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using evaluation.Models;

namespace evaluation.Controllers;

public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;

    public RegisterController(ILogger<RegisterController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        return View();
    }


    [HttpPost]
    public IActionResult Index(RegisterViewModel model)
    {

        if (ModelState.IsValid)
        {
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

