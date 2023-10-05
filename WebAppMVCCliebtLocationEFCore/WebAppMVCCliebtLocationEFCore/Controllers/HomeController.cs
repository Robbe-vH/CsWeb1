using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVCCliebtLocationEFCore.Data;
using WebAppMVCCliebtLocationEFCore.Models;

namespace WebAppMVCCliebtLocationEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ClientLocationContext _context;

        public HomeController(ILogger<HomeController> logger, ClientLocationContext context)
        {
            _logger = logger;
            _context = context;
            _context.Database.EnsureCreated();
            
        }

        public IActionResult Index()
        {
            return View();
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