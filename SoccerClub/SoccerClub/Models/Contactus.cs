using SoccerClub.Data;
using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
	public class ContactUs
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Enter Your First Name")]
		[MaxLength(20, ErrorMessage = "Only 20 Characters are Allowed")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Enter Your Last Name")]
		[MaxLength(20, ErrorMessage = "Only 20 Characters are Allowed")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Enter Your Phone Number(eg.03XXXXXXXXX)")]
		[StringLength(11, ErrorMessage = "Please Enter Valid Phone Number")]
        [RegularExpression("^03[0-9]{9}$", ErrorMessage = "Invalid format. It should start with '03' and have 8 digits.")]
        public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Enter Your Email")]
		[MaxLength(50, ErrorMessage = "Maximum 50 Characters Allowed")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email Address")]
		public string Email { get; set; }
		[MaxLength(250, ErrorMessage = "Maximum 250 Characters Allowed"), Required]
		public string Comment { get; set; }
	}
}
