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

        public IActionResult Create()
        {
            if (Request.Method == "POST")
            {
                int clientId = Convert.ToInt32(Request.Form["ClientId"]);
                int locationId = Convert.ToInt32(Request.Form["LocationId"]);

                if (ModelState.IsValid) Database.AddClient(new Client(clientId, locationId, Request.Form["ClientName"]));
                return RedirectToAction("Index");
            }
            else return View();
        }

    }
}
