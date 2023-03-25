using CliverApi.DTOs.RequestFeatures;
using CliverApi.Models;

namespace CliverApi.Core.Contracts
{
    public interface IRecentPostRepository : IGenericRepository<RecentPost>
    {
        Task CreateRecentPost(int postId, string userId);
        Task<IEnumerable<Post>> GetRecentPosts(string userId, RecentPostParameters param);
    }
}
