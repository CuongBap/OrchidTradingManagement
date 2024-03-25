using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.Enums;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MyEditAuctionOrchidModel : PageModel
    {
        private readonly IListInformationService listInformationService;
        private readonly IAuctionService auctionService;

        [BindProperty]
        public EditListInformation EditListInformationRequest { get; set; }

        [BindProperty]
        public EditAuction EditAuctionRequest { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public MyEditAuctionOrchidModel(IListInformationService listInformationService, IAuctionService auctionService)
        {
            this.listInformationService = listInformationService;
            this.auctionService = auctionService;
        }
        public async Task OnGet(Guid id)
        {
            var listinforDomainModel = await listInformationService.GetAsync(id);
            if (listinforDomainModel != null)
            {
                EditListInformationRequest = new EditListInformation
                {
                    InforId = listinforDomainModel.InforId,
                    Title = listinforDomainModel.Title,
                    Description = listinforDomainModel.Description,
                    Image = listinforDomainModel.Image,
                    CreatedDate = listinforDomainModel.CreatedDate,
                    Status = listinforDomainModel.Status,
                    OrchidId = listinforDomainModel.OrchidId,
                    AuctionId = listinforDomainModel.AuctionId,
                    UserId = listinforDomainModel.UserId,
                };
                if (listinforDomainModel.AuctionId != null)
                {
                    var auctionDomainModel = await auctionService.GetAsync((Guid)EditListInformationRequest.AuctionId);
                    if (auctionDomainModel != null)
                    {
                        EditAuctionRequest = new EditAuction
                        {
                            AuctionId = auctionDomainModel.AuctionId,
                            AuctionName = auctionDomainModel.AuctionName,
                            Deposit = auctionDomainModel.Deposit,
                            StartingBid = auctionDomainModel.StartingBid,
                            OpenDate = auctionDomainModel.OpenDate,
                            CloseDate = auctionDomainModel.CloseDate,

                        };
                    }
                }
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            ValidateAddService();
            if (ModelState.IsValid)
            {

                var listinforDomainModel = new ListInformation
                {
                    InforId = EditListInformationRequest.InforId,
                    Title = EditListInformationRequest.Title,
                    Description = EditListInformationRequest.Description,
                    Image = EditListInformationRequest.Image,
                    CreatedDate = EditListInformationRequest.CreatedDate,
                    Status = ListInformationStatus.Processing.ToString(),
                    OrchidId = EditListInformationRequest.OrchidId,
                    AuctionId = EditListInformationRequest.AuctionId,
                    UserId = EditListInformationRequest.UserId,

                };
                var auctionDomainModel = new Auction
                {
                    AuctionId = EditAuctionRequest.AuctionId,
                    AuctionName = EditAuctionRequest.AuctionName,
                    Deposit = EditAuctionRequest.Deposit,
                    StartingBid = EditAuctionRequest.StartingBid,
                    OpenDate = EditAuctionRequest.OpenDate,
                    CloseDate = EditAuctionRequest.CloseDate,
                };

                await listInformationService.UpdateAsync(listinforDomainModel);
                await auctionService.UpdateAsync(auctionDomainModel);

                TempData["success"] = "Edit successfuly";
                return RedirectToPage("/Orchid/MyAuctionOrchid");
            }
            else
            {
                TempData["error"] = "Edited fail";
                return Page();

            }

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await listInformationService.DeleteAsync(EditListInformationRequest.InforId);
            if (deleted)
            {
                TempData["success"] = "Delete successfully";
                return RedirectToPage("MySellOrchid");
            }

            TempData["Error"] = "Edit Fail";
            return Page();
        }

        private void ValidateAddService()
        {
            if (EditAuctionRequest.OpenDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("EditAuctionRequest.OpenDate",
                    $"OpenDate can only be today's date or a furture date.");
            }

            if (EditAuctionRequest.CloseDate.Date < EditAuctionRequest.OpenDate.Date)
            {
                ModelState.AddModelError("EditAuctionRequest.CloseDate",
                                $"Close date is greater than Open Date.");

            }
        }
    }
}
