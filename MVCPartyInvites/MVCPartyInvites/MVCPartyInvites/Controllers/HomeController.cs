using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Data;
using MVCPartyInvites.Models;
using System.Diagnostics;

namespace MVCPartyInvites.Controllers
{
    public class HomeController : Controller
    {
        PartyContext _context;
        public HomeController(PartyContext context)
        {
            _context = context;
            if(!_context.Gasten.Any() )
            {
                foreach(Gast gast in LocalData.GastList)
                {
                    _context.Gasten.Add(gast);
                }
                _context.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            return View(_context.Gasten);
        }

       
    }
}