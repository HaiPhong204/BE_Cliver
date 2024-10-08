﻿using CliverApi.DTOs.User;
using System.ComponentModel.DataAnnotations;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class UserDto
    {
        public UserDto()
        {
            Posts = new List<PostDto>();
            Languages = new List<Language>();
        }

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int WalletId { get; set; }
        public WalletDto? Wallet { get; set; }
        public UserType Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public bool IsSaved { get; set; }
        public double RatingAvg { get; set; }
        public int RatingCount { get; set; }
        public string? Avatar { get; set; }
        public List<Language> Languages { get; set; }
        public string Skills { get; set; }
        public ICollection<PostDto> Posts { get; set; }
    }
}
