using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Data;
using SoccerClub.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace SoccerClub.Controllers
{
    public class adminController : Controller
    {
        private readonly SoccerClubContext context;

        public adminController(SoccerClubContext soccerClub)
        {
            context = soccerClub;
        }
        public IActionResult OrderDetails()
        {
			var Order = context.Orders.Include(p => p.User).ToList();
			return View(Order);
        }
        public IActionResult SearchResult(string keyword)
        {
            ViewBag.keyword = keyword;
            var ViewModel = new IndexVM
            {
                matches = context.Matches.Include(x => x.AwayTeam).Include(x => x.HomeTeam).Where(m => m.AwayTeam.Name.Contains(keyword) || m.HomeTeam.Name.Contains(keyword)).ToList(),
                player = context.Players.Include(x => x.Team).Where(m => m.Name.Contains(keyword)).ToList(),
                team = context.Teams.Where(m => m.Name.Contains(keyword)).ToList(),
                product = context.Products.Where(m => m.ProductName.Contains(keyword)).ToList(),
            };
            return View(ViewModel);
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
