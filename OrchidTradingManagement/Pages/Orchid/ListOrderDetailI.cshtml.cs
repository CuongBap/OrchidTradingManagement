using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages.Orchid
{
    public class ListOrderDetailIModel : PageModel
    {
        
        private readonly IOrderDetailRepository _orderDetailRepository;

        public List<OrderDetail> ListOrderDetailRequest { get; set; }

        

        public ListOrderDetailIModel(IOrderDetailRepository orderDetailRepository)
        {
            
            this._orderDetailRepository = orderDetailRepository;

        }

        public async Task OnGet()
        {

            ListOrderDetailRequest = (await _orderDetailRepository.GetAllAsync())?.ToList();




            /* var listOrderDetail = await _orderDetailRepository.GetAsync(id);
             if (listOrderDetail != null)
             {
                 ListOrderDetailRequest = new ListOrderDetail
                 {
                     OrderDetailId = listOrderDetail.OrderDetailId,
                     UnitPrice = listOrderDetail.UnitPrice,
                     Quantity = listOrderDetail.Quantity,
                     OrchidId = listOrderDetail.OrchidId,
                     OrderId = listOrderDetail.OrderId

                 };
                 if (listOrderDetail.OrchidId != null)
                 {
                     var orchidproduct = await _orchidRepository.GetAsync((Guid)ListOrderDetailRequest.OrchidId);
                     EditOrchidRequest = new EditOrchid
                     {
                         OrchidId = orchidproduct.OrchidId,
                         OrchidName = orchidproduct.OrchidName,
                         Characteristic = orchidproduct.Characteristic,
                         UnitPrice = orchidproduct.UnitPrice,
                         Quantity = orchidproduct.Quantity,
                     };
                 }*/





        }
    }

}
        
