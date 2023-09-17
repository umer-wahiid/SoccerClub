using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Data;
using SoccerClub.Models;

namespace SoccerClub.Controllers
{
    public class adminController : Controller
    {
        private readonly SoccerClubContext context;

        public adminController(SoccerClubContext soccerClub)
        {
            context = soccerClub;
        }
        public async Task<IActionResult> Index()
        {
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			var soccerClubContext = context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam);
			return View(await soccerClubContext.ToListAsync());
		}
        public IActionResult Users()
		{
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			return View(context.User.ToList());
        }
        public IActionResult FeedBacks()
		{
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			return View(context.Feedbacks.Include(x=>x.User).ToList());
        }
        public IActionResult Teams()
		{
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			return View(context.Teams.ToList());
        }
        public IActionResult Contacts()
		{
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			return View(context.contactUs.ToList());
        }
        public IActionResult Players()
		{
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			return View(context.Players.ToList());
        }
        public async Task<IActionResult> Matches()
		{
			if (Session.IsAdmin == "NO")
			{
				return RedirectToAction("Index", "Home");
			}
			var soccerClubContext = context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam);
            return View(await soccerClubContext.ToListAsync());
        }
    }
}
