using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class SellOrchidInformationModel : PageModel
    {
        private readonly IListInformationRepository _listInformationRepository;

        public IEnumerable<SellOrchidDTO> SellInfors { get; set; }

        public SellOrchidInformationModel(IListInformationRepository listInformationRepository)
        {
            _listInformationRepository = listInformationRepository;
        }

        
        public async Task OnGet()
        { 
            SellInfors = await _listInformationRepository.GetAllSellListInformationAsync(); 
            
        }
    }
}
