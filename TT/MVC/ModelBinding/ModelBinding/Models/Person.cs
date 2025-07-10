using System.ComponentModel.DataAnnotations;

namespace ModelBinding.Models
{
    public class Person
    {
        [StringLength(30,MinimumLength =3,ErrorMessage ="Name should be atleat 3 letter and a max of 30 letter")]
        public string Name { get; set; } = string.Empty;// Default to an empty string to avoid null reference issues

        [Range(18, 18, ErrorMessage = "Age must be between 18 and 30.")]
        public int Age { get; set; }
    }
}
