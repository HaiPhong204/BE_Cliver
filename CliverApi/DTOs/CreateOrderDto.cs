using System.Runtime.Serialization;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class CreateOrderDto
    {
        public CreateOrderDto()
        {
            Note = "";
        }
        public string Note { get; set; }
        public int PackageId { get; set; }
        //public List<OrderHistoryDto>? Histories { get; set; }
    }
}
