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
    }
}
