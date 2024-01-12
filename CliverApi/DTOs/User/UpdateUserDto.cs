using CliverApi.DTOs.User;
using System.ComponentModel.DataAnnotations;
using static CliverApi.Common.Enum;

namespace CliverApi.DTOs
{
    public class UpdateUserDto
    {
        public UpdateUserDto()
        {
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? Avatar { get; set; }
        public List<Language>? Languages{ get; set; }
        public string? Skills{ get; set; }
    }
}
