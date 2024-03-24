using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingManagement.Extension;
using OrchidTradingManagement.Models;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class CartModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public List<Cart> carlist { get; set; }

        public CartModel(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public async Task OnGet()
        {
            carlist = HttpContext.Session.Get<List<Cart>>("cart");
            if (carlist == null)
            {
                carlist = new List<Cart>();
            }
        }

        public async Task<IActionResult> OnPostUpdateQuantity(int index, int quantity)
        {
            carlist = HttpContext.Session.Get<List<Cart>>("cart");
            if (index >= 0 && index < carlist.Count)
            {
                carlist[index].quantity = quantity;
                HttpContext.Session.Set("cart", carlist);
                TempData["Success"] = "Quantity updated successfully.";
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromCart(int index)
        {
            carlist = HttpContext.Session.Get<List<Cart>>("cart");
            if (index >= 0 && index < carlist.Count)
            {
                carlist.RemoveAt(index);
                HttpContext.Session.Set("cart", carlist);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPost(string del)
        {
            carlist = HttpContext.Session.Get<List<Cart>>("cart");
            if (del != null)
            {
                carlist.RemoveAt(int.Parse(del));
                HttpContext.Session.Set("cart", carlist);
            }
            else
            {
                decimal total = 0;
                carlist.ForEach(c => total += c.Product.UnitPrice * c.quantity);
                Order order = await _orderService.AddAsync(new Order
                {
                    OrderId = new Guid(),
                    OrderDate = DateTime.Now,
                    Status = "pending",
                    Total = total,
                    BuyerId = Guid.Parse(HttpContext.Session.GetString("userId"))
                });
                carlist.ForEach(async c => await _orderDetailService.AddSync(new OrderDetail
                {
                    OrderDetailId = new Guid(),
                    UnitPrice = c.quantity * c.Product.UnitPrice,
                    Quantity = c.quantity,
                    OrchidId = c.Product.OrchidId
                }));
                HttpContext.Session.Set("cart", new List<List<Cart>>());
                carlist = new List<Cart>();
                TempData["success"] = "Add to order";
            }
            return Page();
        }
    }
}