using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class ActiveAuctionModel : PageModel
    {
        private readonly IListInformationService _iListInformationService;
        public List<AuctionOrchidDTO> ListInformations { get; set; }

        public ActiveAuctionModel(IListInformationService listInformationService)
        {
            this._iListInformationService = listInformationService;
        }
        public async Task OnGet()
        {
            ListInformations = (await _iListInformationService.GetAllAuctionListInformationAsync())?.ToList();
        }
    }
}
