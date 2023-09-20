using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
	public class Reminder
	{
		public int Id { get; set; }
		public User User { get; set; }
		public int UserId { get; set; }
		public Match Match { get; set; }
		public int MatchId { get; set; }
	}
}