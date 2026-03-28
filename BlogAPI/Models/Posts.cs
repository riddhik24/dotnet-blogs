using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Post
    {
        public int Id {get;set;}

        [Required]
        [MaxLength(50)]
        public string Title {get;set;} = string.Empty;

        [Required]
        public string Content {get;set;} = string.Empty;

        public int AuthorId {get;set;}

        public Author Author{get;set;}= null!;
    }
}