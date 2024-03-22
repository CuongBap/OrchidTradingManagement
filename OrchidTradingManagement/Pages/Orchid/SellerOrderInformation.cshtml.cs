using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class SellerOrderInformationModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        public List<Order> orderRequest { get; set; }
        public SellerOrderInformationModel(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        public async Task OnGet()
        {
            orderRequest = (await _orderRepository.GetAllAsync())?.ToList();
        }
    }
}
