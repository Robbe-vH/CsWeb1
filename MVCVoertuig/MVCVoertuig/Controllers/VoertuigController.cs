using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Controllers;

public class VoertuigController : Controller
{
    VoertuigDbContext _context;

    public VoertuigController(VoertuigDbContext context)
    {
        _context = context;
    }

    public IActionResult Merk(string merk)
    {
        ViewBag.Merk = merk;
        return View(_context.Voertuigen.Where(v => v.Merk == merk));
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _context.Voertuigen.ToListAsync());
    }

    // CREATE
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Voertuig voertuig)
    {
        if (ModelState.IsValid)
        {
            _context.Voertuigen.Add(voertuig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(voertuig);
    }
}