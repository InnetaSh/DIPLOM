
using Globals.Abstractions;
using OfferApiService.Models.RentObjModel;


namespace OfferApiService.Services.Interfaces.RentObj
{
        public interface IRentObjImageService : IServiceBase<RentObjImage>
        {

        Task<string> SaveImageAsync(IFormFile file, int rentObjId);
        Task<bool> DeleteImageAsync(int imageId);
        Task<bool> UpdateImageAsync(int imageId, IFormFile file);

    }
    }

