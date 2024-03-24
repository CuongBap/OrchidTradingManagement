using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Admin
{
    public class AccessListModel : PageModel
    {
        private readonly IListInformationService listInformationService;
        public List<ListInformation> ListInformations { get; set; }

        public AccessListModel(IListInformationService listInformationService)
        {
            this.listInformationService = listInformationService;
        }
        public async Task OnGet()
        {
            ListInformations = (await listInformationService.GetAllAsync())?.ToList();
        }
        
    }
}
