namespace SoccerClub.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public DateTime DOB { get; set; }
    }
}
