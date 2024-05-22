using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetShop.Pages
{
    public class IndexModel(IProductRepository productRepository) : PageModel
    {
        readonly IProductRepository _productRepository = productRepository;

        public IEnumerable<Product> Products { get; set; } = default!;

        public async Task OnGet()
        {
            Products = await _productRepository.GetTopProducts();
        }
    }
}
