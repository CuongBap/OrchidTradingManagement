using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Admin
{
    public class EditSellOrchidInforModel : PageModel
    {
        private readonly IListInformationRepository listInformationRepository;
        private readonly IOrchidRepository orchidRepository;

        [BindProperty]
        public ListInformation ListInformation { get; set; }
  
        [BindProperty]
        public OrchidProduct Orchid { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public EditSellOrchidInforModel(IListInformationRepository listInformationRepository, IOrchidRepository orchidRepository)
        {
          this.listInformationRepository = listInformationRepository;
            this.orchidRepository = orchidRepository;
        }
        
        public async Task OnGet(Guid id)
        {
            ListInformation = await listInformationRepository.GetAsync(id);
            if(ListInformation.OrchidId != null) 
            {
                Orchid = await orchidRepository.GetAsync((Guid)ListInformation.OrchidId);
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await listInformationRepository.UpdateAdminAsync(ListInformation);
                TempData["success"] = "Updated Orchid Successfully";
                
            }catch(Exception ex)
            {
                TempData["error"] = "Update Orchid Fail.";
            }
            return Page();
        }
        }
}
