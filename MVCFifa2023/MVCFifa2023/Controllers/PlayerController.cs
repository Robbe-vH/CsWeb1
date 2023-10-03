using Microsoft.AspNetCore.Mvc;
using MVCFifa2023.Data;
using MVCFifa2023.Models;

namespace MVCFifa2023.Controllers
{
    public class PlayerController : Controller
    {
        ApplicationDbContext _context;
        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var players = _context.Players;
            return View(players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var player = _context.Players.Find(id);
            return View(player);
        }

        //public IActionResult Edit(int id)
        //{
        //    if (player == null)
        //    {
        //        _context
        //        return View(player);
        //    }
        //}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = _context.Players.Find(id);
            return View(player);
        }

        [HttpPost]
        public IActionResult Delete(Player player)
        {
            if (player != null) RemovePlayer(player);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

        }


        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        private void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        private void RemovePlayer(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}
