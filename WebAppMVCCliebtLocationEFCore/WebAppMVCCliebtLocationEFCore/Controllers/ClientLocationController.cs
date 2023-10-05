using Microsoft.AspNetCore.Mvc;
using WebAppMVCCliebtLocationEFCore.Data;
using WebAppMVCCliebtLocationEFCore.ViewModels;

namespace WebAppMVCCliebtLocationEFCore.Controllers
{
    public class ClientLocationController : Controller
    {
        ClientLocationContext _context;

        public ClientLocationController(ClientLocationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clients;
            var locations = _context.Locations;

            var clientLocations = clients.Join(locations,
                c => c.ClientId,
                l => l.LocationId,
                (c, l) => new ClientLocation
                {
                    ClientName = c.ClientName,
                    City = l.City
                });

            return View(clientLocations);
        }
    }
}
