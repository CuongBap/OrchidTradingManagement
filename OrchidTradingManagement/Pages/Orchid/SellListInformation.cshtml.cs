using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingManagement.Extension;
using OrchidTradingManagement.Models;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class SellOrchidInformationModel : PageModel
    {
        private readonly IListInformationRepository _listInformationRepository;
        private readonly IOrchidRepository _orchidRepository;

        public IEnumerable<SellOrchidDTO> SellInfors { get; set; }

        public SellOrchidInformationModel(IListInformationRepository listInformationRepository, IOrchidRepository orchidRepository)
        {
            _listInformationRepository = listInformationRepository;
            _orchidRepository = orchidRepository;
        }


        public async Task OnGet()
        {
            SellInfors = await _listInformationRepository.GetAllSellListInformationAsync();
        }

        public async Task<IActionResult> OnPost(int quantity, Guid id)
        {
            OrchidProduct orchidProduct = await _orchidRepository.GetAsync(id);
            List<Cart> listcart = HttpContext.Session.Get<List<Cart>>("cart");
            if (listcart == null)
            {
                listcart = new List<Cart>();
            }
            bool isIn = false;
            foreach (Cart cart in listcart)
            {
                if (cart.Product.OrchidId == id)
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
            return RedirectToPage("Cart");
        }
    }
}
