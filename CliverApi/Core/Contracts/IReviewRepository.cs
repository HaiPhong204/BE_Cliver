using CliverApi.DTOs;
using CliverApi.Models;
using System.Linq.Expressions;

namespace CliverApi.Core.Contracts
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<Review> CreateReview(int orderId, string userId, CreateReviewDto createDto, Common.Enum.Mode mode);
        Task<IEnumerable<Review>> GetReviewsOfUser(string userId);
        Task<IEnumerable<Review>> GetReviewsOfPost(int postId);
        Task<List<RatingStat>> GetReviewsStats(int postId);
        Task<List<RatingStat>> GetReviewsStatsOfUser(string userId);
    }
}
