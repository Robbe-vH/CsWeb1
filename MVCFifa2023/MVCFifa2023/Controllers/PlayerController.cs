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


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = _context.Players.Find(id);
            return View(player);
        }

        [HttpPost]
        public IActionResult DeletePost(Player player)
        {
            int id = Convert.ToInt32(Request.Form["PlayerId"]);
            var result = _context.Players
                .Where(p => p.PlayerId == id)
                .FirstOrDefault();
            RemovePlayer(result);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _context.Players.Find(id);
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                UpdatePlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
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

        private void RemovePlayer(Player? player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        private void UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }
    }
}
