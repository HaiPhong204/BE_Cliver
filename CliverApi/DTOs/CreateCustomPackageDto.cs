using CliverApi.Models;
using System.ComponentModel.DataAnnotations;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class CreateCustomPackageDto
    {
        public CreateCustomPackageDto()
        {
            Description = null!;
            BuyerId = null!;
        }
        [Required]
        [MinLength(20)]
        public string Description { get; set; }
        public int PostId { get; set; }
        [Required]
        public string BuyerId { get; set; }
        public int DeliveryDays { get; set; }
        public int? NumberOfRevisions { get; set; }
        public int Price { get; set; }
        public int? ExpirationDays { get; set; }
        public int? RoomId { get; set; }
    }
}
