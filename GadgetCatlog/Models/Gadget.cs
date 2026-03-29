using System.ComponentModel.DataAnnotations;

namespace GadgetCatlog.Models
{
    public class Catlog
    {
        public int Id{get;set;}

        [Required]
        [MaxLength(50)]
        public string Name{get;set;} = string.Empty;
        [Required]
        [MaxLength(50)]
        
        public string Category {get;set;} = string.Empty;

        [Required]
        public decimal Price {get;set;}
    }
}