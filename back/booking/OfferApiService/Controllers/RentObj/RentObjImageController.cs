using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Services.Interfaces.RentObj;
using OfferApiService.View.RentObj;

namespace OfferApiService.Controllers.RentObj
{

    public class RentObjImageController : EntityControllerBase<RentObjImage, RentObjImageResponse, RentObjImageRequest>
    {
        private readonly IRentObjImageService _imageService;
        private readonly string _baseUrl;
        public RentObjImageController(IRentObjImageService rentObjImageService, IRabbitMqService mqService, IConfiguration configuration)
             : base(rentObjImageService, mqService)
        {
            _imageService = rentObjImageService;
            _baseUrl = configuration["AppSettings:BaseUrl"];
        }



        [HttpPost("upload/{rentObjId}")]
        public async Task<IActionResult> Upload(int rentObjId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

            string url = await _imageService.SaveImageAsync(file, rentObjId);

            return Ok(new { url });
        }


        [HttpPut("update-file/{imageId}")]
        public async Task<IActionResult> UpdateFile(int imageId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

            bool result = await _imageService.UpdateImageAsync(imageId, file);

            if (!result)
                return NotFound("Изображение не найдено");

            return Ok(new { message = "Файл обновлён" });
        }


        [HttpDelete("delete/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            bool result = await _imageService.DeleteImageAsync(imageId);

            if (!result)
                return NotFound("Изображение не найдено");

            return Ok(new { message = "Удалено" });
        }



        protected override RentObjImage MapToModel(RentObjImageRequest request)
        {
            return RentObjImageRequest.MapToModel(request);
        }


        protected override RentObjImageResponse MapToResponse(RentObjImage model)
        {
            return RentObjImageResponse.MapToResponse(model,_baseUrl);

        }


    }
}