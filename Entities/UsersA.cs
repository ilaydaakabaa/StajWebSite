using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebAppBaslangc.Entities
{
    [Index(nameof(eMail), IsUnique = true)]
    [Index(nameof(userName), IsUnique = true)]
    public class UsersA
    {
        [Key]
        public Guid userId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed.")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain spaces.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "E-mail is required.")]
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-mail is invalid.")]
        public string eMail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[^\s`~!@#$%^&*()_+={}|\[\]:;""'<>,.?/]*$", ErrorMessage = "Password cannot contain special characters.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } = "User"; 
        public bool IsDeleted { get; set; } = false; 

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 
        public DateTime? UpdatedDate { get; set; } 
        public DateTime? DeletedDate { get; set; } 


    }
}
