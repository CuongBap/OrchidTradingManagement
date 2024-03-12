using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class EditStatusOrderModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        [BindProperty]
        public OrderDetail OrderDetails { get; set; } = default!;
        public EditStatusOrderModel(IOrderDetailRepository orderDetailRepository)
        {
            this._orderDetailRepository = orderDetailRepository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (_orderDetailRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var orderDetails = _orderDetailRepository.GetAsync(id);

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
            if (_orderDetailRepository.GetAllAsync() == null)
            {
                return NotFound();
            }
            var orderDetails = _orderDetailRepository.GetAsync(id);

            if (orderDetails != null)
            {
                _orderDetailRepository.DeleteAsync(id);

            }

            return RedirectToPage("./ListOrderInformation");
        }
    }
}
