using System.ComponentModel.DataAnnotations;

namespace WebAppBaslngc.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain spaces.")]
        public string userName { get; set; }

        [MaxLength(100, ErrorMessage = "Max 100 characters allowed")]
        [Required(ErrorMessage = "E-mail is required.")]

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail can only contain alphanumeric characters, dots, underscores, and '@'.")]

       
        public string eMail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 characters allowed")]
        [RegularExpression(@"^[^\s`~!@#$%^&*()_+={}|\[\]:;""'<>,.?/]*$", ErrorMessage = "Password cannot contain special characters.")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Please confirm your password.")]
        public string ConfirmPassword { get; set; }
    }
}
