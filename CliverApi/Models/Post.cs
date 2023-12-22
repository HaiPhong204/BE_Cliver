using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CliverApi.Common.Enum;

namespace CliverApi.Models
{
    [Table("Post")]
    public class Post : AuditEntity
    {
        public Post()
        {
            Status = PostStatus.Draft;
            Tags = string.Empty;
            Images = string.Empty;
            Category = null;
            UserId = null!;
            HasOfferPackages = false;
            Packages = new List<Package>();
        }
        public int Id { get; set; }
        [MinLength(30)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirement { get; set; } = string.Empty;
        public PostStatus Status { get; set; }
        [Column(TypeName = "varchar(36)")]
        public string UserId { get; set; }
        public User? User { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Tags { get; set; }
        public string Images { get; set; }
        public double RatingAvg { get; set; }
        public int RatingCount { get; set; }
        public string? Document { get; set; }
        [NotMapped]
        public bool IsSaved { get; set; }
        public bool HasOfferPackages { get; set; }
        public IEnumerable<Package> Packages { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(e => e.Title);
            builder.HasQueryFilter(p => p.Status == PostStatus.Active);
        }
    }
}
