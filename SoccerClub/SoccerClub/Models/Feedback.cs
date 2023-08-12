using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Only 100 Characters are Allowed")]
        public string Feedbacks { get; set; }
    }
}
