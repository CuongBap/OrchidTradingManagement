using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

namespace OrchidTradingManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IListInformationService _listInformationService;
        
        public List<ListInformation> ListInformation { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IListInformationService listInformationService)
        {
            _logger = logger;
            _listInformationService = listInformationService;
        }

        public void OnGet()
        {

        }
    }
}