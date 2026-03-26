using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts.RentObj;
using ReviewContracts;
using System.Threading.Tasks;
using TranslationContracts;

namespace WebApiGetway.Service.Interfase
{
    public interface IReviewBffService
    {
        Task<ReviewResponse> CreateReview(
              ReviewRequest request,
              string lang);
        //============================================================================================
        Task<IEnumerable<ReviewResponse>> GetReviewByOffer(
           int offerId,
           string lang);

        Task<IEnumerable<ReviewResponse>> GetReviewByUser(
            int userId,
            string lang);

        //============================================================================================
        Task<ReviewResponse> UpdateReviewById(
            ReviewRequest request,
             int reviewId,
            string lang);

        //============================================================================================
        Task<bool> DeleteReviewById(
           int reviewId,
           int userId,
           int orderId);

    }
}
