using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AuthenticationJSON.Models
{
    public class Employer
    {
        [Key ,ForeignKey("User")]
        public int Id { get; set; }
        [Required]
        public string Company { get; set; }
       
        public string Designation { get; set; }

        public User User { get; set; }
    }
}
