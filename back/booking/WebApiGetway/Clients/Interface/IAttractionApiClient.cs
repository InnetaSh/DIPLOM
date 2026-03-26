using AttractionContracts;
using LocationContracts;
using TranslationContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface IAttractionApiClient
    {
        Task<IEnumerable<AttractionResponse>> GetAllAttractionsByCityIdAsync(int cityId);
        Task<AttractionResponse> GetAttractionByIdAsync(int attractionId);
        Task<IEnumerable<AttractionResponse>> GetNearAttractionsByIdWithDistance(
             double latitude,
            double longitude,
            decimal distance);
    }
}
