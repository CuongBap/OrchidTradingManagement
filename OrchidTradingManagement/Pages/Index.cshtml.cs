using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IListInformationService _listInformationService;

        public List<ListInformation> ListInformation { get; set; }
        public IEnumerable<ListInformation> SearchResults { get; set; }
        public string SearchString { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IListInformationService listInformationService)
        {
            _logger = logger;
            _listInformationService = listInformationService;
        }

        public async Task OnGetAsync(string? searchString)
        {
            SearchString = searchString;
            SearchResults = await _listInformationService.SearchListInformationAsync(SearchString);
        }
    }
}