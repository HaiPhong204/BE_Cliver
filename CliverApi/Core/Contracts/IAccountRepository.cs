using CliverApi.Models;
using System.Linq.Expressions;

namespace CliverApi.Core.Contracts
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        Task UpdateBalance(string userId, long balance);
    }
}
