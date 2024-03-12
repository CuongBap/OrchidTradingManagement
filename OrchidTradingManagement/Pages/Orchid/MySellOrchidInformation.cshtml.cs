using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MySellOrchidInformationModel : PageModel
    {
        private readonly IListInformationRepository _listInformationRepository;

        //public IEnumerable<SellOrchidDTO> OrchidInfors { get; set; }

        public MySellOrchidInformationModel(IListInformationRepository listInformationRepository)
        {
            _listInformationRepository = listInformationRepository;
        }

        public async Task OnGet()
        {
            //var id = HttpContext.Session.GetString("userId");
            //if (!string.IsNullOrEmpty(id))
            //{
            //    OrchidInfors = await listInformationRepository.GetAllMySellListInformationAsync(id);
            //}

        }
    }
}
