using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class SellListInformationModel : PageModel
    {
        private readonly IListInformationService listInformationService;
        public List<ListInformation> ListInformations { get; set; }

        public SellListInformationModel(IListInformationService listInformationService)
        {
            this.listInformationService = listInformationService;
        }
        public async Task OnGet()
        {
            ListInformations = (await listInformationService.GetAllAsync())?.ToList();
        }
    }
}
