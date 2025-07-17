using System.ComponentModel.DataAnnotations;

namespace AuthenticationJSON.DTO
{
    public class RegisterSeekerDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
