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

        public IActionResult Details(int id)
        {
            var client = _context.Clients.Find(id);
            return View(client);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.Find(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var client = _context.Clients.Find(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }


    }
}
