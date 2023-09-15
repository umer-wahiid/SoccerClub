using Microsoft.AspNetCore.Mvc;
using SoccerClub.Data;

namespace SoccerClub.Models
{
    public class IndexVMViewComponent: ViewComponent
    {
        public SoccerClubContext _context;

        public IndexVMViewComponent(SoccerClubContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var ID = Session.UserId;
            var matches = _context.Matches.OrderByDescending(m=>m.MatchId).Take(4).ToList();
            var players = _context.Players.ToList();
            var teams = _context.Teams.ToList();
            var products = _context.Products.ToList();

            var ViewModel = new IndexVM
            {
                match = matches,
                player = players,
                team = teams,
                product = products,
                
            };

            return View(ViewModel);
        }
    }
}
