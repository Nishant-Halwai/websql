using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp7.Models;
using WebApp7.Service;

namespace WebApp7.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Products> Products;
        public void OnGet()
        {
            ProductService productsService = new ProductService();
            Products = productsService.getProducts();
        }
    }
}
