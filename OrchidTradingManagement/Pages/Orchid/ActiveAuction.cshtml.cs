using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class ActiveAuctionModel : PageModel
    {
        private readonly IListInformationRepository listInformationRepository;
        public List<ListInformation> ListInformations { get; set; }

        public ActiveAuctionModel(IListInformationRepository listInformationRepository)
        {
            this.listInformationRepository = listInformationRepository;
        }
        public async Task OnGet()
        {
            ListInformations = (await listInformationRepository.GetAllAsync())?.ToList();
        }
    }
}
