using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter Your Username")]
        [MaxLength(20, ErrorMessage = "Only 20 Characters are Allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Your Full Name")]
        [MaxLength(50, ErrorMessage = "Only 50 Characters are Allowed")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Your Email")]
        [MaxLength(40, ErrorMessage = "Only 40 Characters are Allowed")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your Phone Number(eg.03XXXXXXXXX)")]
        [DataType(DataType.PhoneNumber)]
		[RegularExpression("^03[0-9]{9}$", ErrorMessage = "Invalid format. It should start with '03' and have 8 digits.")]
		[MaxLength(11, ErrorMessage = "Invalid Phone Number or Format")]
        public string PhoneNo { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum 500 Characters are Allowed")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Your Password")]
        [MaxLength(30, ErrorMessage = "Only 30 Characters are Allowed")]
        [MinLength(5,ErrorMessage ="Password Must be Consists of 5 characters")]
        public string Password { get; set; }
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword{ get; set; }
        public bool IsAdmin { get;set; } = false;
    }
}
