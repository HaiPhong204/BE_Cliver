﻿using CliverApi.Models;
using System.ComponentModel;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class PostDto : AuditEntity
    {
        public PostDto()
        {
            Category = null!;
            Status = PostStatus.Draft;
            HasOfferPackages = false;
            Packages = new List<PackageDto>();
        }
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirement { get; set; } = string.Empty;
        public string UserId { get; set; } = null!;
        public PostStatus Status { get; set; }
        public UserDto? User { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> Images { get; set; } = new List<string>();
        public string? Video { get; set; }
        public string? Document { get; set; }
        public bool IsSaved { get; set; }
        public double RatingAvg { get; set; }
        public int RatingCount { get; set; }
        public bool HasOfferPackages { get; set; }
        public ICollection<PackageDto> Packages { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int MinPrice
        {
            get
            {
                if (Packages == null || Packages.Count == 0)
                {
                    return 0;
                }
                int? minPriceNullable = Packages.Min(p => p.Price);
                return minPriceNullable ?? 0;
            }
        }
    }

}
