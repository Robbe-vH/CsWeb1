using Microsoft.AspNetCore.Mvc;
using MVCFifa2023.Data;
using MVCFifa2023.Models;

namespace MVCFifa2023.Controllers
{
    public class TeamController : Controller
    {
        private ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var team = new Team();
            return View(team);
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }
    }
}