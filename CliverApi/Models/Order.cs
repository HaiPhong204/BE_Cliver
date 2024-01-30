using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using static CliverApi.Common.Enum;

namespace CliverApi.Models
{
    [Table("Order")]
    public class Order : AuditEntity
    {
        public Order()
        {
            Note = "";
            CandidateId = null!;
            RecruiterId = null!;
            Histories = new List<OrderHistory>();
            Reviews = new List<Review>();
        }
        public int Id { get; set; }
        public long Price { get; set; }
        public string Note { get; set; }
        public DateTime DueBy { get; set; }
        [Column(TypeName = "varchar(36)")]
        public string CandidateId { get; set; }
        public User? Candidate { get; set; }
        public int RevisionTimes { get; set; }
        public int LeftRevisionTimes { get; set; }
        public long LockedMoney { get; set; }
        public string RecruiterId { get; set; }
        public User? Recruiter { get; set; }
        public int PackageId { get; set; }
        public Package? Package { get; set; }
        public OrderStatus? Status { get; set; }
        public List<OrderHistory> Histories { get; set; }
        public List<Review> Reviews { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(b => b.Package).WithMany(p => p.Orders).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Candidate).WithMany(p => p.Orders).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
