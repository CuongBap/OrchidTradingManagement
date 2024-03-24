using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MyAuctionOrchidModel : PageModel
    {
        private readonly IListInformationService _listInformationService;
        public IEnumerable<AuctionOrchidDTO> Auctions { get; set; }

        public MyAuctionOrchidModel(IListInformationService listInformationService)
        {
            _listInformationService = listInformationService;
        }
        public async Task OnGet()
        {
            var id = HttpContext.Session.GetString("userId");
            if (!string.IsNullOrEmpty(id))
            {
                Auctions = await _listInformationService.GetAllMyAuctionListInformationAsync(id);
            }
        }
    }
}
