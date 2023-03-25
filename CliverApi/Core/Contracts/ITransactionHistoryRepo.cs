using CliverApi.Models;
using System.Linq.Expressions;

namespace CliverApi.Core.Contracts
{
    public interface ITransactionHistoryRepo : IGenericRepository<TransactionHistory>
    {
        Task CreateTransaction(TransactionHistory dtoTrans);
        Task<IEnumerable<TransactionHistory>> GetTransactions(int walletId);
    }
}
