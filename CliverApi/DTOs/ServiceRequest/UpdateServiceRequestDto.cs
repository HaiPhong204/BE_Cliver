﻿using CliverApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class UpdateServiceRequestDto
    {
        public UpdateServiceRequestDto()
        {
            Tags = new List<string>();
            Description = null!;
        }
        [MinLength(20)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<string> Tags { get; set; }
        public long? Budget { get; set; }
        public DateTime? Deadline { get; set; }
    }

}
