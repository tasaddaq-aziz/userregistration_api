using System.ComponentModel.DataAnnotations;

namespace UserRegistrationAPI.Entities.ViewModels
{
    public class UserViewModel
    {

        public int UseriD { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[()*;:!@#$%^&\\-`.+=]).*$", ErrorMessage = "Password must contain atleast one: Upper Case Character, Lower Case Character, Special Character, Number and must be at least 8 characters long.")]
        public string Password { get; set; }
    }
}
