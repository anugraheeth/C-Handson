using System.ComponentModel.DataAnnotations;

namespace TaskItem.Models
{
    public class TaskItems
    {
        [Required(ErrorMessage = "plaese enter a title")]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }


    }
}
