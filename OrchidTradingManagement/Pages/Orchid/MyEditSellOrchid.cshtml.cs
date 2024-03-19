using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.Enums;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class MyEditSellOrchidModel : PageModel
    {
        private readonly IOrchidRepository orchidRepository;
        private readonly IListInformationRepository listInformationRepository;

        [BindProperty]
        public EditListInformation EditListInformationRequest { get; set; }

        [BindProperty]
        public EditOrchid EditOrchidRequest { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public MyEditSellOrchidModel(IListInformationRepository listInformationRepository, IOrchidRepository orchidRepository)
        {
            this.orchidRepository = orchidRepository;
            this.listInformationRepository = listInformationRepository;
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
                if (listinforDomainModel.OrchidId != null)
                {
                    var orchidDomainModel = await orchidRepository.GetAsync((Guid)EditListInformationRequest.OrchidId);
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

                    await listInformationRepository.UpdateAsync(listinforDomainModel);
                    await orchidRepository.UpdateAsync(orchidDomainModel);

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
            if(deleted) {
                TempData["success"] = "Delete successfully";
                return RedirectToPage("MySellOrchid");
            }

            TempData["Error"] = "Edit Fail";
            return Page();
        }
    }
}
