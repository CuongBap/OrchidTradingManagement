using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class AddAuctionInformationModel : PageModel
    {
        private readonly IListInformationService _iListInformationService;
        private readonly IAuctionService _iAuctionService;

        [BindProperty]
        public AddListInformation AddListInformationRequest { get; set; }
        [BindProperty]
        public IFormFile? FeaturedImage { get; set; }

        [BindProperty]
        public AddAuction AddAuctionRequest { get; set; }

        public AddAuctionInformationModel(IListInformationService listInformationService, IAuctionService auctionService)
        {
            this._iListInformationService = listInformationService;
            this._iAuctionService = auctionService;
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
            var userId = HttpContext.Session.GetString("userId");
            if(userId == null)
            {
                return BadRequest("You haven't logined");
            }
            ValidateAddService();
            if (ModelState.IsValid)
            {
                var result = await _iListInformationService.AddAsync( userId , null, AddListInformationRequest, AddAuctionRequest);
                if (result != null)
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

        private void ValidateAddService()
        {
            if (AddAuctionRequest.OpenDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("AddAuctionRequest.OpenDate",
                    $"OpenDate can only be today's date or a furture date.");
            }

            if(AddAuctionRequest.CloseDate.Date < AddAuctionRequest.OpenDate.Date)
            {
                ModelState.AddModelError("AddAuctionRequest.CloseDate",
                                $"Close date is greater than Open Date.");
                    
            }
        }
    }
}
