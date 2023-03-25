using CliverApi.Core.Contracts;
using CliverApi.Error;
using CliverApi.Models;
using AutoMapper;
namespace CliverApi.Core.Repositories
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {
        public AccountRepository(DataContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public async Task UpdateBalance(string userId, long balance)
        {
            var user = Find(u => u.Id == userId).FirstOrDefault();
            if (user == null)
            {
                throw new ApiException(message: "User not found", statusCode: 400);
            }
            //user.Balance += balance;
            await _context.SaveChangesAsync();
        }

    }
}
