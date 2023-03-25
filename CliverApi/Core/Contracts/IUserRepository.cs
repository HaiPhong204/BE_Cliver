using CliverApi.DTOs.User;
using CliverApi.DTOs;
using CliverApi.Models;

namespace CliverApi.Core.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByEmailAndPassword(string email, string password);
        Task<User> FindByEmail(string email);
        Task<bool> CreateNewUser(User user);
        Task VerifyAccount(string userId, VerifySellerDto dto);
        Task<User> GetUserDetails(string userId);
        Task<bool> DepositMoneyIntoWallet(string userId, long amount);
        Task<bool> Withdraw(string userId, long amount);
        Task<User> GetUserInfo(string userId);
        Task UpdateInfo(string userId, UpdateUserDto updateUserDto);
        Task<IEnumerable<User>> Search(string search, string? userId);
        Task<User> FindById(string id, string? logginUserId);
    }
}
