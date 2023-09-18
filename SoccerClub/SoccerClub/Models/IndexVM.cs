using Microsoft.EntityFrameworkCore;

namespace SoccerClub.Models
{
    [Keyless]
    public class IndexVM
    {

        public IEnumerable<Match> match { get; set; }
        public IEnumerable<Match> matches { get; set; }
        public IEnumerable<Team> team { get; set; }
        public IEnumerable<Product> product { get; set; }
        public IEnumerable<Player> player { get; set; }
        public IEnumerable<Player> awayplayer { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public Match Match { get; set; }
        public Root WorldCup { get; set; }
        public Root UEFA { get; set; }
        public Root Premier { get; set; }




    }
}
