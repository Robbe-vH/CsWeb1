using Microsoft.AspNetCore.Mvc;
using WebAppMvcClientLocation.Data;
using WebAppMvcClientLocation.Models;

namespace WebAppMvcClientLocation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View(Database.Clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client c)
        {
            if (ModelState.IsValid) Database.AddClient(new Client(c.ClientId, c.LocationId, c.ClientName));
            return RedirectToAction("Index");
        }

    }
}
