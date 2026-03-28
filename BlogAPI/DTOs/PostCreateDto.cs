using System.ComponentModel.DataAnnotations;

namespace BlogAPI.DTOs
{
    public class PostCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title{get;set;} = string.Empty;

        [Required]
        public string Content {get;set;} = string.Empty;

        [Required]
        public int AuthorId {get;set;}
    }
}