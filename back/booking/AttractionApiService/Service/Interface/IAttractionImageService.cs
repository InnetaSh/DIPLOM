
using Globals.Abstractions;
using AttractionApiService.Models;


namespace AttractionApiService.Service.Interfaces
{
    public interface IAttractionImageService : IServiceBase<AttractionImage>
    {
        Task<string> SaveImageAsync(IFormFile file, int attractionId);
        Task<bool> DeleteImageAsync(int imageId);
        Task<bool> UpdateImageAsync(int imageId, IFormFile file);
     
    }
}

