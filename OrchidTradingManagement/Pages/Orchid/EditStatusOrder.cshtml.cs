using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class EditStatusOrderModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;
        [BindProperty]
        public OrderDetail OrderDetails { get; set; } = default!;
        public EditStatusOrderModel(IOrderDetailService orderDetailService)
        {
            this._orderDetailService = orderDetailService;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (_orderDetailService.GetAllAsync() == null)
            {
                return NotFound();
            }
            var orderDetails = _orderDetailService.GetAsync(id);

            if (orderDetails == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetails = await orderDetails;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (_orderDetailService.GetAllAsync() == null)
            {
                return NotFound();
            }
            var orderDetails = _orderDetailService.GetAsync(id);

            if (orderDetails != null)
            {
                _orderDetailService.DeleteAsync(id);

            }

            return RedirectToPage("./ListOrderInformation");
        }
    }
}
