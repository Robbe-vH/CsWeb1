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
        public IActionResult Create(Client client)
        {
            //if (Request.Method == "POST")
            //{
            //    Client client = new Client(
            //        Convert.ToInt32(Request.Form["ClientId"]),
            //        Convert.ToInt32(Request.Form["LocationId"]),
            //        Request.Form["clientname"]);

            //    if (ModelState.IsValid)
            //    {
            //        if (Database.Clients.Where(c => c.ClientId == client.ClientId).Count() != 0 || client.ClientId < 1)
            //        {
            //            ModelState.AddModelError("", "ClientId bestaat al of kleiner dan 1");
            //            return View("Index");
            //        }
            //        else
            //        {
            //            Database.AddClient(client);
            //        }
            //    }
            //    return RedirectToAction("Index");
            //}
            //else return View();

            if (ModelState.IsValid)
            {
                // check ongeldig clientId
                if (Database.Clients.Where(c => c.ClientId == client.ClientId).Count() != 0 || client.ClientId < 1)
                {
                    ModelState.AddModelError("", "ClientId bestaat al of kleiner dan 1");
                    return View("Index", client);
                }
                Database.AddClient(client);
                return RedirectToAction("Index");
            }
            return View("Index", client);
        }

    }
}
