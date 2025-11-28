using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{

    public class RentObjImageController : EntityControllerBase<RentObjImage, RentObjImageResponse, RentObjImageRequest>
    {
        private readonly IRentObjImageService _imageService;
        public RentObjImageController(IRentObjImageService rentObjImageService, IRabbitMqService mqService)
             : base(rentObjImageService, mqService)
        {
            _imageService = rentObjImageService;
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
    


        protected RentObjImage MapToModel(RentObjImageRequest request)
        {
            return new RentObjImage
            {
                id = request.id,
                Url = request.Url,
                RentObjId = request.RentObjId
            };
        }

        protected RentObjImageResponse MapToResponse(RentObjImage model)
        {
            return new RentObjImageResponse
            {
                id = model.id,
                Url = model.Url,
                RentObjId = model.RentObjId
            };
        }


    }
}