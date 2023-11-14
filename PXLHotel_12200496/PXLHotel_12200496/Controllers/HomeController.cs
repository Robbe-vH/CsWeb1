using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PXLHotel_12200496.Data;
using PXLHotel_12200496.Models;

namespace MVCVoertuig.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private HotelDbContext _context;

    public HomeController(ILogger<HomeController> logger, HotelDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Hotels"] = _context.Hotels.ToList();
        return View(_context.HotelRooms.ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult NewHotel()
    {
        return View();
    }

    public IActionResult NewHotelRoom()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}