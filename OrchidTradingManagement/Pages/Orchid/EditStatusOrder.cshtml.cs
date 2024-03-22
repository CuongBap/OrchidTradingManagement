using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;


namespace OrchidTradingManagement.Pages.Orchid
{
    public class EditStatusOrderModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        
        [BindProperty]
        public Order EditOrderRequest { get; set; }
        public EditOrder EditOrderResponse { get; set; }
        public EditStatusOrderModel(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IOrchidRepository orchidRepository)
        {
            this._orderRepository = orderRepository;
        }


        public async Task OnGet(Guid id)
        {
            EditOrderRequest = await _orderRepository.GetAsync(id);
           
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var orders = new Order
                {
                    OrderId = EditOrderRequest.OrderId,
                    OrderDate = EditOrderRequest.OrderDate,
                    Status = EditOrderRequest.Status,
                    Total = EditOrderRequest.Total,
                };
                await _orderRepository.UpdateAsync(orders);

                TempData["success"] = "Edit successfuly";
                return Page();

            }
            else
            {
                TempData["error"] = "Edited fail";
                return Page();

            }
        }


    }
}

