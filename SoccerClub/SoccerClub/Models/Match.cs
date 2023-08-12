using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        [Required(ErrorMessage = "Enter Venue")]
        [MaxLength(40, ErrorMessage = "Only 40 Characters are Allowed")]
        public string Venue { get; set; }
        [Required(ErrorMessage = "Enter Season")]
        [MaxLength(10, ErrorMessage = "Only 10 Characters are Allowed")]
        public string Season { get; set; }
        [Required(ErrorMessage = "Enter League Name")]
        [MaxLength(40, ErrorMessage = "Only 40 Characters are Allowed")]
        public string League { get; set; }
    }
}
