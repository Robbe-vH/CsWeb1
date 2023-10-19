using Microsoft.AspNetCore.Mvc;
using MVCSportsStore.Data;

namespace MVCSportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        StoreDbContext _context;

        public NavigationMenuViewComponent(StoreDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
