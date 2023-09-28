using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Models;

namespace MVCPartyInvites.Controllers
{
    public class GastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Reservatie(Gast gast)
        {
            if (ModelState.IsValid)
            {
                if (gast.Naam.Length < 2)
                {
                    ModelState.AddModelError("", "Naam is te kort");
                    return View("Index", gast);
                }
                // LocalData.GastList.Add(gast);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index", gast);
            }
        }
    }
}
