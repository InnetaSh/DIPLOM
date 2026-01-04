
using AttractionApiService.Models;
using AttractionApiService.Service.Interfaces;
using AttractionApiService.View;
using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AttractionApiService.Controllers
{

    public class AttractionImageController : EntityControllerBase<AttractionImage, AttractionImageResponse, AttractionImageRequest>
    {
        private readonly IAttractionImageService _imageService;
        private readonly string _baseUrl;
        public AttractionImageController(IAttractionImageService attractionImageService, IRabbitMqService mqService, IConfiguration configuration)
             : base(attractionImageService, mqService)
        {
            _imageService = attractionImageService;
            _baseUrl = configuration["AppSettings:BaseUrl"];
        }



        [HttpPost("upload/{attractionId}")]
        public async Task<IActionResult> Upload(int attractionId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

            string url = await _imageService.SaveImageAsync(file, attractionId);

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



        protected override AttractionImage MapToModel (AttractionImageRequest request)
        {
            return  AttractionImageRequest.MapToModel(request);
        }


        protected override AttractionImageResponse MapToResponse(AttractionImage model)
        {
            return AttractionImageResponse.MapToResponse(model,_baseUrl);

        }


    }
}