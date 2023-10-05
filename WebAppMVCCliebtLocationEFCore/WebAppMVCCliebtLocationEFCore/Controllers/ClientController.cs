using Microsoft.AspNetCore.Mvc;
using WebAppMVCCliebtLocationEFCore.Data;
using WebAppMVCCliebtLocationEFCore.Models;

namespace WebAppMVCCliebtLocationEFCore.Controllers
{
    public class ClientController : Controller
    {
        ClientLocationContext _context;

        public ClientController(ClientLocationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clients;
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }


    }
}
