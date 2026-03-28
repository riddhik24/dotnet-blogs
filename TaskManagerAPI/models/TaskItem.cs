using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        public int Id{get;set;}

        [Required]
        [MaxLength(100)]
        public string Title{get;set;} = string.Empty;

        public bool IsCompleted {get;set;}
        
    }
}