using AttractionContracts;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranslationContracts;

namespace WebApiGetway.Service.Interfase
{
    public interface IAttractionBffService
    {
        Task<IEnumerable<AttractionResponse>> GetAllAttractionByCityId(
           int cityId,
           string lang);

        //===============================================================================================================

        Task<AttractionResponse> GetAttractionById(
          int attractionId,
          string lang);

        //===============================================================================================================

        Task<IEnumerable<AttractionResponse>> GetNearAttractionsByIdWithDistance(
              int offerId,
              decimal distance,
              string lang);
    }

}
