namespace SoccerClub.Models
{
    public class Match
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public string Venue { get; set; }
        public string Season { get; set; }
        public string League { get; set; }
    }
}
