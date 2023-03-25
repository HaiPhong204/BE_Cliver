using CliverApi.DTOs.Order;
using CliverApi.DTOs.User;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class TransactionHistoryDto
    {
        public int Id { get; set; }
        public long Amount{ get; set; }
        public TransactionType Type{ get; set; }
        public int? OrderId { get; set; }
        public OrderDto? Order { get; set; }
        public int WalletId { get; set; }
        public WalletDto? Wallet{ get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
