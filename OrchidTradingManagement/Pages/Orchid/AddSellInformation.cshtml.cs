using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class AddSellInformationModel : PageModel
    {
        private readonly IListInformationService listInformationService;
        private readonly IOrchidService orchidService;

        [BindProperty]
        public AddListInformation AddListInformationRequest { get; set; }

        [BindProperty]
        public AddOrchid AddOrchidRequest { get; set; }

        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        public AddSellInformationModel(IListInformationService listInformationService, IOrchidService orchidService)
        {
            this.listInformationService = listInformationService;
            this.orchidService = orchidService;
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
            //await listInformationService.AddAsync(listInformation);

            //return Page();

            var userId = HttpContext.Session.GetString("userId");
            if(userId == null)
            {
                return BadRequest("You haven't logined");
            }
            if(ModelState.IsValid)
            {
                var result = await listInformationService.AddAsync(userId ,AddOrchidRequest, AddListInformationRequest, null);
                if(result != null)
                {
                    TempData["success"] = "Create successfuly";
                    return Page();
                }
                else
                {
                    TempData["error"] = "Create fail";
                    return Page();
                }
                
            }
            
            return Page();

        }
    }
}
