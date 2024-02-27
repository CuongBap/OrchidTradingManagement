using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class AddAuctionInformationModel : PageModel
    {
        private readonly IListInformationRepository listInformationRepository;
        private readonly IAuctionRepository auctionRepository;

        [BindProperty]
        public AddListInformation AddListInformationRequest { get; set; }

        [BindProperty]
        public AddAuction AddAuctionRequest { get; set; }

        public AddAuctionInformationModel(IListInformationRepository listInformationRepository, IAuctionRepository auctionRepository)
        {
            this.listInformationRepository = listInformationRepository;
            this.auctionRepository = auctionRepository;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            //var listInformation = new ListInformation()
            //{
            //    Title = AddListInformationRequest.Title,
            //    Description = AddListInformationRequest.Description,
            //    Image = AddListInformationRequest.Image,
            //    CreatedDate = DateTime.Now,
            //    Status = AddListInformationRequest.Status,
            //};
            //await listInformationRepository.AddAsync(listInformation);

            //return Page();

            await listInformationRepository.AddAsync(null, AddListInformationRequest, AddAuctionRequest);
            return Page();

        }
    }
}
