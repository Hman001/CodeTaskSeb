using System.ComponentModel.DataAnnotations;

namespace CodeTaskSeb.Models
{ 
    public class CustomerContact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Social Security Number must be numeric")]
        public string? SSN { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [RegularExpression(@"^(\+46)?\d{9}$", ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }
    }
}
