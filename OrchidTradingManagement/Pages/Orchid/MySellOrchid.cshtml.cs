using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MySellOrchidModel : PageModel
    {
        private readonly IListInformationRepository _listInformationRepository;
        public IEnumerable<SellOrchidDTO> Orchids { get; set; }
        public async Task OnGet()
        {
            var id = HttpContext.Session.GetString("userId");
            if(!string.IsNullOrEmpty(id))
            {
                Orchids = await _listInformationRepository.GetAllMySellListInformationAsync(id);
            }
        }
    }
}
