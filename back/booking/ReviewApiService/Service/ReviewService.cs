using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using ReviewApiService.Models;
using ReviewApiService.Service.Interface;


namespace ReviewApiService.Service
{
   
    public class ReviewService : TableServiceBaseNew<Review, ReviewContext>, IReviewService
    {
        public ReviewService(ReviewContext context, ILogger<ReviewService> logger) : base(context, logger)
        {
        }

        public async Task<List<Review>> GetReviewsByOfferId(int offerId)
        {
            _logger.LogInformation("Getting reviews for OfferId {OfferId}", offerId);

            var reviews = await _context.Reviews
                .AsNoTracking()
                .Where(r => r.OfferId == offerId && r.IsApproved)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} reviews for OfferId {OfferId}", reviews.Count, offerId);

            return reviews;
        }

        public async Task<List<Review>> GetReviewsByUserId(int userId)
        {
            _logger.LogInformation("Getting reviews for UserId {UserId}", userId);

            var reviews = await _context.Reviews
                 .AsNoTracking()
                .Where(r => r.UserId == userId && r.IsApproved)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} reviews for UserId {UserId}", reviews.Count, userId);

            return reviews;
        }


        public async Task<double> GetRatingByOfferId(int offerId)
        {
            _logger.LogInformation("Calculating rating for OfferId {OfferId}", offerId);

            var rating = await _context.Reviews
                 .AsNoTracking()
                .Where(r => r.OfferId == offerId && r.IsApproved)
                .AverageAsync(r => (double?)r.OverallRating);

            var result = rating ?? 0;

            _logger.LogInformation("Rating for OfferId {OfferId} = {Rating}", offerId, result);

            return result;
        }

        public async Task<Dictionary<int, double>> GetRatingsByOfferIds(List<int> offerIds)
        {
            if (offerIds == null || offerIds.Count == 0)
            {
                _logger.LogWarning("GetRatingsByOfferIds called with empty offerIds");
                return new Dictionary<int, double>();
            }

            _logger.LogInformation("Calculating ratings for {Count} offers", offerIds.Count);

            var ratings = await _context.Reviews
                 .AsNoTracking()
                .Where(r => r.IsApproved && offerIds.Contains(r.OfferId))
                .GroupBy(r => r.OfferId)
                .ToDictionaryAsync(
                    g => g.Key,
                    g => g.Average(r => r.OverallRating)
                );

            _logger.LogInformation("Calculated ratings for {Count} offers", ratings.Count);

            return ratings;
        }

        //public async Task<Dictionary<int, OfferReviewStats>> GetOfferReviewStatsAsync(IEnumerable<int> offerIds)
        //{
        //   
        //    var reviews = await _context.Reviews
        //        .Where(r => offerIds.Contains(r.OfferId) && r.IsApproved)
        //        .ToListAsync();

        //    var stats = reviews
        //        .GroupBy(r => r.OfferId)
        //        .ToDictionary(
        //            g => g.Key,
        //            g => new OfferReviewStats
        //            {
        //                OfferId = g.Key,
        //                AverageRating = g.Any() ? g.Average(r => r.OverallRating) : 0,
        //                IsRecommended = g.Count() >= 20 && g.Average(r => r.OverallRating) >= 8.5,
        //                IsTopLocation = g.Any(r => r.Location >= 9),
        //                IsTopCleanliness = g.Any(r => r.Cleanliness >= 9)
        //            });


        //    foreach (var id in offerIds.Except(stats.Keys))
        //    {
        //        stats[id] = new OfferReviewStats
        //        {
        //            OfferId = id,
        //            AverageRating = 0,
        //            IsRecommended = false,
        //            IsTopLocation = false,
        //            IsTopCleanliness = false
        //        };
        //    }

        //    return stats;
        //}
    }
}
