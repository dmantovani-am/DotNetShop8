using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetShop.Pages
{
    public class CartModel : PageModel
    {
        readonly ICartRepository _cartRepository;
        readonly IProductRepository _productRepository;

        public IList<CartItem>? Items { get; set; }

        public decimal Total { get; set; }

        public CartModel(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Items = await _cartRepository.GetItems();
            if (Items.Count == 0) return RedirectToPage("/Cart/Empty");

            Total = await _cartRepository.GetTotal();

            return Page();
        }

        public async Task<IActionResult> OnGetAdd(int id)
        {
            var product = await _productRepository.Get(id);
            if (product == null) return NotFound(id);

            await _cartRepository.Add(product);

            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnGetRemove(int id)
        {
            var product = await _productRepository.Get(id);
            if (product == null) return NotFound(id);

            await _cartRepository.Remove(product);

            return RedirectToPage("Cart");
        }
    }
}
