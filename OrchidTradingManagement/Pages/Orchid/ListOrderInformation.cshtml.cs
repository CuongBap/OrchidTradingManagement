using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class ListOrderInformationModel : PageModel
    {
        private readonly IOrderService _orderService;
        [BindProperty]
        public List<Order> Orders { get; set; }

        public ListOrderInformationModel(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        public async Task OnGet()
        {
            Orders = (await _orderService.GetAllAsync())?.ToList();
        }
    }
}
