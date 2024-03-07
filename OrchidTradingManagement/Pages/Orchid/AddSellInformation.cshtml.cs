using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class AddSellInformationModel : PageModel
    {
        private readonly IListInformationRepository listInformationRepository;
        private readonly IOrchidRepository orchidRepository;

        [BindProperty]
        public AddListInformation AddListInformationRequest { get; set; }

        [BindProperty]
        public AddOrchid AddOrchidRequest { get; set; }

        public AddSellInformationModel(IListInformationRepository listInformationRepository, IOrchidRepository orchidRepository)
        {
            this.listInformationRepository = listInformationRepository;
            this.orchidRepository = orchidRepository;
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
            if(ModelState.IsValid)
            {
                var result = await listInformationRepository.AddAsync(userId ,AddOrchidRequest, AddListInformationRequest, null);
            }
            
            return Page();

        }
    }
}
