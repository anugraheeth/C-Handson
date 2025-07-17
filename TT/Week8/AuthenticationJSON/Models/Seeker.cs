using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationJSON.Models
{
    public class Seeker
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public int Age { get; set; }

        public User User { get; set; } 
    }
}
