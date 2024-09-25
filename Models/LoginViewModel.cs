using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppBaslangc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = " Username or Email is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [DisplayName("Username or Email")]
        public required string userNameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 characters allowed")]
        [RegularExpression(@"^[^\s`~!@#$%^&*()_+={}|\[\]:;""'<>,.?/]*$", ErrorMessage = "Password cannot contain special characters.")]
        public string password { get; set; }
    }
}
