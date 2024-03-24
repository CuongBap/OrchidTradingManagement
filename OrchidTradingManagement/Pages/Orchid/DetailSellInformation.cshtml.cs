using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingManagement.Extension;
using OrchidTradingManagement.Models;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class DetailSellInformationModel : PageModel
    {
        private readonly IListInformationService listInformationService;
        private readonly IOrchidService orchidService;
        public ListInformation ListInformation { get; set; }
        public OrchidProduct orchidProduct { get; set; }
        public int quantity = 1;

        public DetailSellInformationModel(IListInformationService listInformationService, IOrchidService orchidService)
        {
            this.listInformationService = listInformationService;
            this.orchidService = orchidService;
        }

        public async Task OnGet(string id)
        {
            ListInformation = await listInformationService.GetAsync(Guid.Parse(id));
        }

        public async Task<IActionResult> OnPost(int quantity, Guid id)
        {
            orchidProduct = await orchidService.GetAsync(id);
            List<Cart> listcart = HttpContext.Session.Get<List<Cart>>("cart");
            if (listcart == null)
            {
                listcart = new List<Cart>();
            }
            bool isIn = false;
            foreach (Cart cart in listcart)
            {
                if(cart.Product.OrchidId == id)
                {
                    cart.quantity += quantity;
                    isIn = true;
                    break;
                }
            }
            if (!isIn)
            {
                listcart.Add(new Cart
                {
                    Product = orchidProduct,
                    quantity = quantity
                });
            }
            HttpContext.Session.Set("cart", listcart);
            TempData["success"] = "Add product to cart";
            return RedirectToPage("SellListInformation");
        }
    }
}
