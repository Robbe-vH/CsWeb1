using Microsoft.AspNetCore.Mvc;
using MVCSportsStore.Data;
using MVCSportsStore.Models;
using MVCSportsStore.ViewModels;
using System.Diagnostics;

namespace MVCSportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StoreDbContext _context;
        private ProductRepository _repo;

        public HomeController(ILogger<HomeController> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;
            _repo = new ProductRepository(_context);
        }

        public IActionResult Index(int id = 1)
        {
            return View(_repo.GetProductModel(id));
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