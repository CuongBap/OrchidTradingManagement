using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.Enums;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MyEditSellOrchidModel : PageModel
    {
        private readonly IOrchidService orchidService;
        private readonly IListInformationService listInformationService;

        [BindProperty]
        public EditListInformation EditListInformationRequest { get; set; }

        [BindProperty]
        public EditOrchid EditOrchidRequest { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public MyEditSellOrchidModel(IListInformationService listInformationService, IOrchidService orchidService)
        {
            this.orchidService = orchidService;
            this.listInformationService = listInformationService;
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
                if (listinforDomainModel.OrchidId != null)
                {
                    var orchidDomainModel = await orchidService.GetAsync((Guid)EditListInformationRequest.OrchidId);
                    if (orchidDomainModel != null)
                    {
                        EditOrchidRequest = new EditOrchid
                        {
                            OrchidId = orchidDomainModel.OrchidId,
                            OrchidName = orchidDomainModel.OrchidName,
                            Characteristic = orchidDomainModel.Characteristic,
                            UnitPrice = orchidDomainModel.UnitPrice,
                            Quantity = orchidDomainModel.Quantity,

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
                    var orchidDomainModel = new OrchidProduct
                    {
                        OrchidId = EditOrchidRequest.OrchidId,
                        OrchidName = EditOrchidRequest.OrchidName,
                        Characteristic = EditOrchidRequest.Characteristic,
                        UnitPrice = EditOrchidRequest.UnitPrice,
                        Quantity = EditOrchidRequest.Quantity,
                    };

                    await listInformationService.UpdateAsync(listinforDomainModel);
                    await orchidService.UpdateAsync(orchidDomainModel);

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
            var deleted = await listInformationService.DeleteAsync(EditListInformationRequest.InforId);
            if(deleted) {
                TempData["success"] = "Delete successfully";
                return RedirectToPage("MySellOrchid");
            }

            TempData["Error"] = "Edit Fail";
            return Page();
        }
    }
}
