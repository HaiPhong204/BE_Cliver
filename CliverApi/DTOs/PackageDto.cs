using CliverApi.Models;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class PackageDto
    {
        public PackageDto()
        {
        }
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PostId { get; set; }
        public SimplePostDto? Post { get; set; }
        public PackageStatus Status { get; set; }
        public int DeliveryDays { get; set; }
        public bool IsAvailable { get; set; }
        public int? NumberOfRevisions { get; set; }
        public int? Price { get; set; }
        public PackageType Type { get; set; }
    }
}
