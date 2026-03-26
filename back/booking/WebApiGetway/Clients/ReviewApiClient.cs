using Globals.Clients;
using LocationContracts;
using OfferContracts.RentObj;
using ReviewContracts;
using StatisticContracts;
using System.Net.Http.Json;
using TranslationContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Clients
{
    public class ReviewApiClient : BaseApiClient, IReviewApiClient
    {
     
        public ReviewApiClient(HttpClient client, ILogger<ReviewApiClient> logger)
       : base(client, logger) { }


        //===============================================================================================================
        //      ADD METHODS CREATE REVIEWS
        //===============================================================================================================
        public async Task<ReviewResponse> CreateReviewAsync(ReviewRequest request)
        {
            var result = await PostAsync<ReviewResponse>(
                "/api/review/review/create",
                request);
            return result ?? new ReviewResponse();
        }

        //===============================================================================================================
        //      UPDATE METHODS REVIEWS
        //===============================================================================================================
        public async Task<ReviewResponse> UpdateReviewAsync(int reviewId, ReviewRequest request)
        {
            var result = await PostAsync<ReviewResponse>(
                $"/api/review/update/{reviewId}",
                request);
            return result ?? new ReviewResponse();
        }

        //===============================================================================================================
        //      DELETE REVIEWS
        //===============================================================================================================
        public async Task DeleteReviewAsync(int reviewId)
        {
            await DeleteAsync(
                $"/api/review/del/{reviewId}");
        }
        //===============================================================================================================
        //     OFFERS REVIEWS
        //===============================================================================================================
        public async Task<IEnumerable<RatingResponse>> GetOffersRatingAsync(List<int> idList)
        {
            var result = await PostAsync<IEnumerable<RatingResponse>>(
                "/api/review/search/offers/rating",
                idList);
            return result ?? Enumerable.Empty<RatingResponse>();
        }

        //===============================================================================================================
        //      GET OFFER REVIEWS BY offerId
        //===============================================================================================================
        public async Task<IEnumerable<ReviewResponse>> GetOfferReviewsByOfferIdAsync(int offerId)
        {
            var result = await GetAsync<IEnumerable<ReviewResponse>>( $"/api/review/get-by-offerId/{offerId}");
            return result ?? Enumerable.Empty<ReviewResponse>();
        }
        //===============================================================================================================
        //       GET OFFER REVIEWS BY userId
        //===============================================================================================================

        public async Task<IEnumerable<ReviewResponse>> GetOfferReviewsByUserIdAsync(int userId)
        {
            var result = await GetAsync<IEnumerable<ReviewResponse>>($"/api/review/get-by-userId/{userId}");
            return result ?? Enumerable.Empty<ReviewResponse>();
        }



    }
}
