using LocationContracts;
using ReviewContracts;
using StatisticContracts;
using TranslationContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface IReviewApiClient
    {
        Task<ReviewResponse> CreateReviewAsync(ReviewRequest request);
        Task<ReviewResponse> UpdateReviewAsync(int reviewId, ReviewRequest request);
        Task DeleteReviewAsync(int reviewId);
        //-------------------------------------------------------------------------------------

        Task<IEnumerable<RatingResponse>> GetOffersRatingAsync(List<int> idList);


        //-------------------------------------------------------------------------------------

        Task<IEnumerable<ReviewResponse>> GetOfferReviewsByOfferIdAsync(int id);
        Task<IEnumerable<ReviewResponse>> GetOfferReviewsByUserIdAsync(int userId);
        //-------------------------------------------------------------------------------------

    }
}
