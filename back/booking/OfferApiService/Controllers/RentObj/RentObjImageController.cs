using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Mappers;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Services.Interfaces.RentObj;
using OfferContracts.RentObj;

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
            //_baseUrl = configuration["AppSettings:BaseUrl"];
            _baseUrl = $"{configuration["HostUrl"] ?? "http://localhost"}:5003";
        }



        [HttpPost("upload/{rentObjId}")]
        public async Task<ActionResult<string>> Upload(int rentObjId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

            string url = await _imageService.SaveImageAsync(file, rentObjId);

            return Ok( url );
        }


        [HttpPut("update-file/{imageId}")]
        public async Task<ActionResult<bool>> UpdateFile(int imageId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не передан");

            bool result = await _imageService.UpdateImageAsync(imageId, file);

            if (!result)
                return Ok(false);

            return Ok(true);
        }


        [HttpDelete("delete/{imageId}")]
        public async Task<ActionResult<bool>> DeleteImage(int imageId)
        {
            bool result = await _imageService.DeleteImageAsync(imageId);

            if (!result)
                return Ok(false);

            return Ok(true);
        }



        protected override RentObjImage MapToModel(RentObjImageRequest request)
        {
            return RentObjImageMapper.MapToModel(request);
        }


        protected override RentObjImageResponse MapToResponse(RentObjImage model)
        {
            return RentObjImageMapper.MapToResponse(model,_baseUrl);

        }


    }
}