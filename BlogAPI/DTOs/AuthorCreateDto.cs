using System.ComponentModel.DataAnnotations;

namespace BlogAPI.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}