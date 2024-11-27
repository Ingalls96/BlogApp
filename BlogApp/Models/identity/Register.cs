using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{

    public class Register
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName {get; set; }

        [Required]
        public string LastName {get; set; }

        public string PhoneNumber {get; set; }

    }
}