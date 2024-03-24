using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MySellOrchidModel : PageModel
    {
        private readonly IListInformationService _listInformationService;
        public IEnumerable<SellOrchidDTO> Orchids { get; set; }
        public MySellOrchidModel(IListInformationService listInformationService)
        {
            _listInformationService = listInformationService;
        }
        public async Task OnGet()
        {
            var id = HttpContext.Session.GetString("userId");
            if(!string.IsNullOrEmpty(id))
            {
                Orchids = await _listInformationService.GetAllMySellListInformationAsync(id);
            }
        }
    }
}
