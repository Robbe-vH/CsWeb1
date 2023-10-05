using Microsoft.AspNetCore.Mvc;
using WebAppMVCCliebtLocationEFCore.Data;
using WebAppMVCCliebtLocationEFCore.Models;

namespace WebAppMVCCliebtLocationEFCore.Controllers
{
    public class LocationController : Controller
    {
        ClientLocationContext _context;

        public LocationController(ClientLocationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var locations = _context.Locations;
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(location);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        public IActionResult Details(int id)
        {
            var location = _context.Locations.Find(id);
            return View(location);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var location = _context.Locations.Find(id);
            return View(location);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Update(location);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var location = _context.Locations.Find(id);
            return View(location);
        }

        [HttpPost]
        public IActionResult Delete(Location location)
        {
            _context.Locations.Remove(location);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
