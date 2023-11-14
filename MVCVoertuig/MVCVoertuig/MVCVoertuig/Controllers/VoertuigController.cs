using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Controllers
{
    [Authorize]
    public class VoertuigController : Controller
    {
        #region DI
        VoertuigDbContext _context;
        public VoertuigController(VoertuigDbContext context)
        {
            _context = context;
        }
        #endregion

        public IActionResult Index()
        {
            return View(_context.Voertuigen);
        }
        public IActionResult Merk(string merk)
        {
            ViewBag.Merk = merk;
            var filter = _context.Voertuigen.Where(x=>x.Merk == merk);  
            return View(filter);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Voertuig voertuig)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Voertuigen.Add(voertuig);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch 
                {
                    ModelState.AddModelError("", "Onverwachte fout bij het opslaan van een voertuig!");
                }                
            }
            return View(voertuig);
        }
        #endregion
    }
}
