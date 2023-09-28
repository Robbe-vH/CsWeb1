using Microsoft.AspNetCore.Mvc;
using WebAppMvcClientLocation.Data;
using WebAppMvcClientLocation.Models;

namespace WebAppMvcClientLocation.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            location.LocationId = Database.Locations.Count;
            if (ModelState.IsValid)
            {

                Database.AddLocation(location);
            }

            return RedirectToAction("Index");
        }
    }
}
