using Microsoft.AspNetCore.Mvc;
using SoccerClub.Data;

namespace SoccerClub.Controllers
{
    public class adminController : Controller
    {
        private readonly SoccerClubContext context;

        public adminController(SoccerClubContext soccerClub)
        {
            this.context = soccerClub;
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
        public IActionResult Matches()
        {
            return View(context.Matches.ToList());
        }
    }
}
