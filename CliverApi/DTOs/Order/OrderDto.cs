using static CliverApi.Common.Enum;

namespace CliverApi.DTOs.Order
{
    public class OrderDto : BaseDto
    {
        public OrderDto()
        {
            Note = "";
            RecruiterId = null!;
            CandidateId = null!;
            Histories = new List<OrderHistoryDto>();
        }
        public int Id { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public DateTime DueBy { get; set; }
        public string RecruiterId { get; set; }
        public UserDto? Recruiter { get; set; }
        public string CandidateId { get; set; }
        public UserDto? Candidate { get; set; }
        public int RevisionTimes { get; set; }
        public int LeftRevisionTimes { get; set; }
        public int PackageId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PackageDto? Package { get; set; }
        public OrderStatus? Status { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public List<OrderHistoryDto> Histories { get; set; }
    }
}
