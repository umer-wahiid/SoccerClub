using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Data;
using SoccerClub.Models;
using System.Diagnostics;

namespace SoccerClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SoccerClubContext db;

        public HomeController(ILogger<HomeController> logger, SoccerClubContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            var ViewModel = new IndexVM
            {
                match = db.Matches.OrderByDescending(m => m.MatchId).Take(4).ToList(),
                matches = db.Matches.OrderByDescending(m => m.MatchId).Take(5).ToList(),
                player = db.Players.ToList(),
                team = db.Teams.ToList(),
                product = db.Products.ToList(),
            };
            return View(ViewModel);
        }

        public IActionResult Matches()
        {
            var match = db.Matches.Include(m=>m.AwayTeam).Include(m=>m.HomeTeam).
                ToList();
            return View(match);
        }


		// GET: Matches/Details/5
		public async Task<IActionResult> MatchesDetail(int? id)
		{
			if (id == null || db.Matches == null)
			{
				return NotFound();
			}

			var match = await db.Matches
				.Include(m => m.AwayTeam)
				.Include(m => m.HomeTeam)
				.FirstOrDefaultAsync(m => m.MatchId == id);
			if (match == null)
			{
				return NotFound();
			}

			return View(match);
		}

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            var match = db.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam).
                ToList();
            return View(match);
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Players()
        {
            return View(db.Players.ToList());
        }

        public async Task<IActionResult> PlayersDetail(int? id)
        {
            if (id == null || db.Players == null)
            {
                return NotFound();
            }

            var player = await db.Players.Include(p => p.Team).FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Contact")]
        public IActionResult Contact(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                db.contactUs.Add(contactUs);
                db.SaveChanges();
                ViewBag.Contact = "Thanks For Reaching Out";

                return View();
            }
            return View(contactUs);
        }
        
        [HttpGet]
        public IActionResult Feedback()
        {

            if (Session.UserId != 0)
            {

                ViewBag.Name = HttpContext.Session.GetString("name");
                return View();
            }
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public IActionResult Feedback(Feedback feed)
        {
                feed.UserId = Session.UserId;
                db.Feedbacks.Add(feed);
                db.SaveChanges();
                ViewBag.feedback = "Thanks For Your Feedback";

                return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}