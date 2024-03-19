using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MyAuctionOrchidModel : PageModel
    {
        private readonly IListInformationRepository _listInformationRepository;
        public IEnumerable<AuctionOrchidDTO> Auctions { get; set; }

        public MyAuctionOrchidModel(IListInformationRepository listInformationRepository)
        {
            _listInformationRepository = listInformationRepository;
        }
        public async Task OnGet()
        {
            var id = HttpContext.Session.GetString("userId");
            if (!string.IsNullOrEmpty(id))
            {
                Auctions = await _listInformationRepository.GetAllMyAuctionListInformationAsync(id);
            }
        }
    }
}
