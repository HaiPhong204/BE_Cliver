using System.ComponentModel.DataAnnotations.Schema;

namespace CliverApi.DTOs.User
{
    public class CreateSavedListDto
    {
        public CreateSavedListDto()
        {
        }
        public string Name { get; set; } = string.Empty;
    }
}
