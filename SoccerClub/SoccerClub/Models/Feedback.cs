namespace SoccerClub.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public string Feedbacks { get; set; }
    }
}
