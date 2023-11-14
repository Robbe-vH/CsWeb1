using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Data;
using MVCPartyInvites.Models;

namespace MVCPartyInvites.Controllers
{
    [Authorize]
    public class GastController : Controller
    {
        PartyContext _context;
        public GastController(PartyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Gast g = new Gast();
            return View(g);
        }
        
        [HttpPost]
        public IActionResult Reservatie(Gast g)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(g.Naam) || g.Naam.Length<2)
                {
                    ModelState.AddModelError("", "Naam is te kort");
                    return View("Index", g);
                }
                if(_context.Gasten.Where(x=>x.Email == g.Email).Any())
                {
                    ModelState.AddModelError("", "Email bestaat al!");
                    return View("Index", g);
                }
                if (AddGast(g))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Probleem bij het toevoegen van een gast!");
                    return View("Index", g);
                }
            }
            return View("Index", g);
        }
        private bool AddGast(Gast gast)
        {
            bool succeeded = false;
            try
            {                
                _context.Gasten.Add(gast);
                _context.SaveChanges();
                succeeded = true;
            }
            catch 
            {
                succeeded = false;
            }
            return succeeded;
        }

    }
}


