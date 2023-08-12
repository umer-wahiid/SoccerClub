using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required(ErrorMessage = "Enter Team Name")]
        [MaxLength(50, ErrorMessage = "Only 50 Characters are Allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Teams Country Name")]
        [MaxLength(15, ErrorMessage = "Only 15 Characters are Allowed")]
        public string Country { get; set; }

        //[Required(ErrorMessage = "Enter Teams Logo")]
        //[MaxLength(100, ErrorMessage = "Only 100 Characters are Allowed")]
        public string LogoUrl { get; set; }
    }
}
