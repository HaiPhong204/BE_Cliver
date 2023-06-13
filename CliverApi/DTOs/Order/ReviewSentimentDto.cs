using System;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs.Order
{
	public class ReviewSentimentDto
	{
        public ReviewSentimentDto()
        {
            Comment = string.Empty;
        }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? Label { get; set; }
    }
}

