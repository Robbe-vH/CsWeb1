using Microsoft.AspNetCore.Mvc;
using MVCSportsStore.ViewModels;

namespace MVCSportsStore.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PagingSettingsView()
        {
            PagingsettingsViewModel paging = new PagingsettingsViewModel();
            paging.ProductPagination = PagingSettings.ProductPagination;
            return View(paging);
        }

        [HttpPost]
        public IActionResult PagingSettingsView(PagingsettingsViewModel paging)
        {
            PagingSettings.ProductPagination = paging.ProductPagination;
            return RedirectToAction("Index", "Home");
        }
    }
}