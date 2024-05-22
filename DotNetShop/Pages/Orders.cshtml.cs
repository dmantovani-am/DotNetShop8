using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetShop.Pages
{
    public class OrdersModel : PageModel
    {
        readonly IOrderRepository _orderRepository;

        [BindProperty]
        public Order? Order { get; set; }

        public OrdersModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Order != null && ModelState.IsValid)
            {
                var order = Order!;
                await _orderRepository.Add(order);

                return RedirectToPage("/Orders/Success", new { orderId = order.Id });
            }

            return Page();
        }
    }
}
