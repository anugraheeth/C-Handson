using System.ComponentModel.DataAnnotations;

namespace AuthenticationJSON.DTO
{
    public class RegisterEmployerDto
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
        public string Company { get; set; }
        public string Designation { get; set; }
    }
}
