using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Author
    {
        public int Id {get;set;}

        [Required]
        [MaxLength(50)]

        public string Name {get;set;} = string.Empty;

        [Required]
        [EmailAddress]
        public string Email {get;set;} = string.Empty;

        public List<Post> Posts{get;set;} = [];
    }
}