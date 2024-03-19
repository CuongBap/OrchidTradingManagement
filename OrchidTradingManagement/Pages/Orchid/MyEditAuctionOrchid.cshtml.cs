using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.Enums;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MyEditAuctionOrchidModel : PageModel
    {
        private readonly IListInformationRepository listInformationRepository;
        private readonly IAuctionRepository auctionRepository;

        [BindProperty]
        public EditListInformation EditListInformationRequest { get; set; }

        [BindProperty]
        public EditAuction EditAuctionRequest { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public MyEditAuctionOrchidModel(IListInformationRepository listInformationRepository, IAuctionRepository auctionRepository)
        {
            this.listInformationRepository = listInformationRepository;
            this.auctionRepository = auctionRepository;
        }
        public async Task OnGet(Guid id)
        {
            var listinforDomainModel = await listInformationRepository.GetAsync(id);
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
                    var auctionDomainModel = await auctionRepository.GetAsync((Guid)EditListInformationRequest.AuctionId);
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

                await listInformationRepository.UpdateAsync(listinforDomainModel);
                await auctionRepository.UpdateAsync(auctionDomainModel);

                TempData["success"] = "Edit successfuly";
                return Page();
            }
            else
            {
                TempData["error"] = "Edited fail";
                return Page();

            }

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await listInformationRepository.DeleteAsync(EditListInformationRequest.InforId);
            if (deleted)
            {
                TempData["success"] = "Delete successfully";
                return RedirectToPage("MySellOrchid");
            }

            TempData["Error"] = "Edit Fail";
            return Page();
        }
    }
}
