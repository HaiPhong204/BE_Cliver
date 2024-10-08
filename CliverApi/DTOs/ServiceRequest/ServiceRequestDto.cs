﻿using CliverApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class ServiceRequestDto : BaseDto
    {
        public ServiceRequestDto()
        {
            Description = string.Empty;
            Description = string.Empty;
            Tags = new List<string>();
            UserId = null!;
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public UserDto? User { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<string> Tags { get; set; }
        public long? Budget { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? DoneAt { get; set; }
    }

}
