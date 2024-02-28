using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ModelsRequest
{
    public class UserEntityRequestModel
    {
        
        [Required(ErrorMessage = "{0} should not be empty")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First name start with Cap and Should have minimum 3 character")]
        [RegularExpression(@"^[A-Z]{1}[a-zA-Z ]{2,}$", ErrorMessage = "UserName is not valid")]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(320, ErrorMessage = "Email address should not exceed 320 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [StringLength(10,  ErrorMessage = "Password must be 10 characters long.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile number. Please enter a 10-digit number without any spaces or special characters.")]

        public string? MobileNumber { get; set; }
    }
}
