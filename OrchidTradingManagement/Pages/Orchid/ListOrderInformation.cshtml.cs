using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class ListOrderInformationModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        [BindProperty]
        public List<Order> Orders { get; set; }

        public ListOrderInformationModel(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public async Task OnGet()
        {
            Orders = (await _orderRepository.GetAllAsync())?.ToList();
        }
    }
}
