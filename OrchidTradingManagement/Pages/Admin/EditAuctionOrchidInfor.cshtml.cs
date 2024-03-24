using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Admin
{
    public class EditAuctionOrchidInforModel : PageModel
    {
        private readonly IListInformationService listInformationService;
        private readonly IAuctionService auctionService;

        [BindProperty]
        public ListInformation ListInformation { get; set; }

        [BindProperty]
        public Auction Auction { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public EditAuctionOrchidInforModel(IListInformationService listInformationService, IAuctionService auctionService)
        {
            this.listInformationService = listInformationService;
            this.auctionService = auctionService;  
        }
        public async Task OnGet(Guid id)
        {
            ListInformation = await listInformationService.GetAsync(id);
            if (ListInformation.AuctionId != null)
            {
                Auction = await auctionService.GetAsync((Guid)ListInformation.AuctionId);
            }
        }
        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await listInformationService.UpdateAdminAsync(ListInformation);
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
