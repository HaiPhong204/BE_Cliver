using CliverApi.DTOs.Master;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs.Order
{
    public class OrderActionDto
    {
        public OrderActionType Action { get; set; }
        public CreateResouceDto? Resource { get; set; }
    }
}
