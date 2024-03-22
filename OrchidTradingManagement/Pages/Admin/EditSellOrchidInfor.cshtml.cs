using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

namespace OrchidTradingManagement.Pages.Admin
{
    public class EditSellOrchidInforModel : PageModel
    {
        private readonly OrchidTradingServices.IListInformationService listInformationService;
        private readonly OrchidTradingServices.IOrchidService orchidService;

        [BindProperty]
        public ListInformation ListInformation { get; set; }
  
        [BindProperty]
        public OrchidProduct Orchid { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public EditSellOrchidInforModel(OrchidTradingServices.IListInformationService listInformationService, OrchidTradingServices.IOrchidService orchidService)
        {
          this.listInformationService = listInformationService;
            this.orchidService = orchidService;
        }
        
        public async Task OnGet(Guid id)
        {
            ListInformation = await listInformationService.GetAsync(id);
            if(ListInformation.OrchidId != null) 
            {
                Orchid = await orchidService.GetAsync((Guid)ListInformation.OrchidId);
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await listInformationService.UpdateAdminAsync(ListInformation);
                TempData["success"] = "Updated Orchid Successfully";
                
            }catch(Exception ex)
            {
                TempData["error"] = "Update Orchid Fail.";
            }
            return Page();
        }
        }
}
