using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetShop.Pages
{
    public class ProductsModel : PageModel
    {
        readonly IProductRepository _productRepository;

        public IEnumerable<Product> Products { get; set; }

        public ProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            Products = Enumerable.Empty<Product>();
        }

        public async Task OnGet()
        {
            Products = await _productRepository.GetAll();
        }
    }
}
