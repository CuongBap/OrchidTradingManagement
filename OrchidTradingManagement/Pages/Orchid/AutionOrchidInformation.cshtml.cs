using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class AutionOrchidInformationModel : PageModel
    {
        private readonly IListInformationRepository _listInformationRepository;

        public IEnumerable<AuctionOrchidDTO> AuctionInfors { get; set; }

        public AutionOrchidInformationModel(IListInformationRepository listInformationRepository)
        {
            _listInformationRepository = listInformationRepository;
        }
        public async Task OnGet()
        {
            AuctionInfors = await _listInformationRepository.GetAllAuctionListInformationAsync();
        }
    }
}
