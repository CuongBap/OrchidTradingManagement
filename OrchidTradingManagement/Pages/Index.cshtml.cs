using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IListInformationRepository _listInformationRepository;

        public List<ListInformation> ListInformation { get; set; }
        public IEnumerable<ListInformation> SearchResults { get; set; }
        public string SearchString { get; set; }
        public IndexModel(ILogger<IndexModel> logger,
            IListInformationRepository listInformationRepository)
        {
            _logger = logger;
            _listInformationRepository = listInformationRepository;
        }

        public async Task OnGetAsync(string? searchString)
        {
            SearchString = searchString;
            SearchResults = await _listInformationRepository.SearchListInformationAsync(SearchString);
        }
    }
}