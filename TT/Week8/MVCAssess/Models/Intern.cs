using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVCAssess.Models
{
    public class Intern
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please provide a qulaification")]
        public string Qualification { get; set; }

        [Required(ErrorMessage ="please provide a score")]
        public float CGPA { get; set; }

        public string? Contact { get; set; }

    }
}
