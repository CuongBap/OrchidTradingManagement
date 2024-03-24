using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class SellOrchidInformationModel : PageModel
    {
        private readonly IListInformationService _listInformationService;

        public IEnumerable<SellOrchidDTO> SellInfors { get; set; }

        public SellOrchidInformationModel(IListInformationService listInformationService)
        {
            _listInformationService = listInformationService;
        }

        
        public async Task OnGet()
        { 
            SellInfors = await _listInformationService.GetAllSellListInformationAsync(); 
            
        }
    }
}
