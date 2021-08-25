using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMailBox.Models;
using System;
using System.Diagnostics;

namespace MyMailBox.Controllers
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
      ViewBag.Date = DateTime.Now;
      return View();
    }
    public IActionResult BadHttp()
    {
      return StatusCode(400);
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
