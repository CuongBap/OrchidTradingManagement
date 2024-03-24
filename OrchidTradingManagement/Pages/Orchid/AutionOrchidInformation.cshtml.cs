using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class AutionOrchidInformationModel : PageModel
    {
        private readonly IListInformationService _listInformationService;

        public IEnumerable<AuctionOrchidDTO> AuctionInfors { get; set; }

        public AutionOrchidInformationModel(IListInformationService listInformationService)
        {
            _listInformationService = listInformationService;
        }
        public async Task OnGet()
        {
            AuctionInfors = await _listInformationService.GetAllAuctionListInformationAsync();
        }
    }
}
