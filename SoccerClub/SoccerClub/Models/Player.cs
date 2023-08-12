using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "Enter Your Full Name")]
        [MaxLength(50, ErrorMessage = "Only 50 Characters are Allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Player's Nationality")]
        [MaxLength(20, ErrorMessage = "Only 20 Characters are Allowed")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Enter Player's Position(*GoalKepper)")]
        [MaxLength(20, ErrorMessage = "Only 20 Characters are Allowed")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Select Player's Image")]
        [MaxLength(15, ErrorMessage = "Only 15 Characters are Allowed")]
        public string PlayerImage { get; set; }
        [Required]
        public int Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        [CustomValidation(typeof(Player), "ValidateDOB")]
        public DateTime DOB { get; set; }
        public static ValidationResult ValidateDOB(DateTime dob, ValidationContext validationContext)
        {
            if (dob > DateTime.Now)
            {
                return new ValidationResult("Date of birth can not be in the future.");
            }

            return ValidationResult.Success;
        }
    }
   
}

