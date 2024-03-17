using Microsoft.AspNetCore.Mvc;
using OrchidTradingRepositories.Repositories;
using System.Net;

namespace OrchidTradingManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Imagescontroller : Controller
    {
        private readonly IImageRepository imageRepository;

        //    private readonly IImageRepository imageRepository;
        //    public ImagesController(IImageRepository imageRepository)
        //    {
        //        this.imageRepository = imageRepository;
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> UploadAsync(IFormFile file)
        //    {
        //        var imageUrl = await imageRepository.UploadAsync(file);

        //        if (imageUrl == null)
        //        {
        //            return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);

        //        }
        //        return Json(new { link = imageUrl });
        //    }

        public Imagescontroller(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file) 
        {
            var imageUrl = await imageRepository.UploadAsync(file);
            if (imageUrl == null)
            {
                return Problem("Something went wromg!", null,(int)HttpStatusCode.InternalServerError);
            }
            return Json(new { link = imageUrl });
        }
    }
}
