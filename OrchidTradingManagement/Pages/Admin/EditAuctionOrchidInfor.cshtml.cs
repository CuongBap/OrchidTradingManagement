using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Admin
{
    public class EditAuctionOrchidInforModel : PageModel
    {
        private readonly IListInformationRepository listInformationRepository;
        private readonly IAuctionRepository auctionRepository;

        [BindProperty]
        public ListInformation ListInformation { get; set; }

        [BindProperty]
        public Auction Auction { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public EditAuctionOrchidInforModel(IListInformationRepository listInformationRepository, IAuctionRepository auctionRepository)
        {
            this.listInformationRepository = listInformationRepository;
            this.auctionRepository = auctionRepository;
        }
        public async Task OnGet(Guid id)
        {
            ListInformation = await listInformationRepository.GetAsync(id);
            if (ListInformation.AuctionId != null)
            {
                Auction = await auctionRepository.GetAsync((Guid)ListInformation.AuctionId);
            }
        }
        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await listInformationRepository.UpdateAdminAsync(ListInformation);
                TempData["success"] = "Updated Orchid Successfully";

            }
            catch (Exception ex)
            {
                TempData["error"] = "Update Orchid Fail.";
            }
            return Page();
        }
    }
}
