using MVCSportsStore.Data;
using MVCSportsStore.Models;

namespace MVCSportsStore.ViewModels
{
    public class ProductRepository
    {
        private StoreDbContext _context;

        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        private IEnumerable<Product> GetProducts(int productPage)
        {
            return _context.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PagingSettings.ProductPagination)
                .Take(PagingSettings.ProductPagination);
        }

        private PagingInfo GetPagingInfo(int productPage)
        {
            return new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PagingSettings.ProductPagination,
                Totalitems = _context.Products.Count()
            };
        }

        public ProductModel GetProductModel(int productPage)
        {
            return new ProductModel
            {
                Products = GetProducts(productPage),
                PagingInfo = GetPagingInfo(productPage)
            };
        }
    }
}