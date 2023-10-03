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

        public IActionResult Create()
        {
            if (Request.Method == "POST")
            {
                var location = new Location(Database.Locations.Count + 1, Request.Form["postcode"], Request.Form["city"]);
                if (ModelState.IsValid)
                {

                    Database.AddLocation(location);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
