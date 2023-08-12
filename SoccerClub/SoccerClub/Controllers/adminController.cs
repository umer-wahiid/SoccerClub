using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Data;

namespace SoccerClub.Controllers
{
    public class adminController : Controller
    {
        private readonly SoccerClubContext context;

        public adminController(SoccerClubContext soccerClub)
        {
            context = soccerClub;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View(context.User.ToList());
        }
        public IActionResult FeedBacks()
        {
            return View(context.Feedbacks.ToList());
        }
        public IActionResult Teams()
        {
            return View(context.Teams.ToList());
        }
        public IActionResult Contacts()
        {
            return View(context.contactUs.ToList());
        }
        public IActionResult Players()
        {
            return View(context.Players.ToList());
        }
        public async Task<IActionResult> Matches()
        {
            var soccerClubContext = context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam);
            return View(await soccerClubContext.ToListAsync());
        }
    }
}
