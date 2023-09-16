using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SoccerClub.Data;
using SoccerClub.Models;
using System.Diagnostics;
using SoccerClub.API;
using Microsoft.DotNet.MSIdentity.Shared;

namespace SoccerClub.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly SoccerClubContext db;
		private readonly IApiHelper _apiHelper;

		public HomeController(ILogger<HomeController> logger, SoccerClubContext db, IApiHelper apiHelper)
		{
			_logger = logger;
			this.db = db;
			this._apiHelper = apiHelper;
		}
		public IActionResult TopTen()
		{

			var jsonContent = _apiHelper.TopTenScores();
			jsonContent = jsonContent.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
			Root apiResponse = JsonConvert.DeserializeObject<Root>(jsonContent);
			//var jsonObject = JObject.Parse(jsonContent);
			//var CompetitionArray = jsonObject["scorers"].ToString();
			//Root responseList = JsonConvert.DeserializeObject<Root>(jsonContent);
			//return View(responseList);
			return View(apiResponse);
		}

		public IActionResult Index()
		{
            ViewBag.Home = "toactive";
			var jsonContent = _apiHelper.GetRecentUpdates();
			jsonContent = jsonContent.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
			var jsonObject = JObject.Parse(jsonContent);
			var articlesArray = jsonObject["articles"].ToString();

			List<Article> responseList = JsonConvert.DeserializeObject<List<Article>>(articlesArray);

			var ViewModel = new IndexVM
			{
				match = db.Matches.OrderByDescending(m => m.MatchId).Take(4).ToList(),
				matches = db.Matches.OrderByDescending(m => m.MatchId).Take(5).ToList(),
				player = db.Players.ToList(),
				team = db.Teams.ToList(),
				product = db.Products.ToList(),
				Articles = responseList

			};
			return View(ViewModel);
		}
		public ActionResult Search(string keyword)
		{
			ViewBag.keyword = keyword;
			var ViewModel = new IndexVM
			{
				matches = db.Matches.Where(m => m.AwayTeam.Name.Contains(keyword) || m.HomeTeam.Name.Contains(keyword)).ToList(),
				player = db.Players.Where(m => m.Name.Contains(keyword)).ToList(),
				team = db.Teams.Where(m => m.Name.Contains(keyword)).ToList(),
				product = db.Products.Where(m => m.ProductName.Contains(keyword)).ToList(),
			};
			return View(ViewModel);
		}
		public async Task<IActionResult> ProductDetail(int? id)
		{
            ViewBag.shop = "toactive";
            if (id == null || db.Products == null)
			{
				return NotFound();
			}

			var product = await db.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.ProductId == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		public IActionResult Matches()
		{
			ViewBag.matches = "toactive";
			var match = db.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam).
				ToList();
			return View(match);
		}


		// GET: Matches/Details/5
		public async Task<IActionResult> MatchesDetail(int? id)
		{
            ViewBag.matches = "toactive";
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
		public async Task<IActionResult> Shop()
		{
            ViewBag.shop = "toactive";
            ViewBag.CategoryId = db.Category.ToList();
			return View(await db.Products.ToListAsync());
		}

		public IActionResult Schedule()
		{
            ViewBag.schedule = "toactive";
			var match = db.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam).
				ToList();
			return View(match);
		}
		public IActionResult Blog()
		{
            ViewBag.blog = "toactive";
            var jsonContent = _apiHelper.GetRecentUpdates();
			jsonContent = jsonContent.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
			var jsonObject = JObject.Parse(jsonContent);
			var articlesArray = jsonObject["articles"].ToString();

			List<Article> responseList = JsonConvert.DeserializeObject<List<Article>>(articlesArray);

			return View(responseList);
		}
		public IActionResult BlogDetails(string url)
		{
            ViewBag.blog = "toactive";
            var jsonContent = _apiHelper.GetRecentUpdates();
			var jsonObject = JObject.Parse(jsonContent);
			var articlesArray = jsonObject["articles"].ToString();
			List<Article> articles = JsonConvert.DeserializeObject<List<Article>>(articlesArray);

			Article article = articles.FirstOrDefault(a => a.Url == url);
			if (article != null)
			{
				return View(article);
			}
			return View();

			// Handle article not found case (e.g., redirect to an error page)
		}
		public IActionResult Players()
		{
            ViewBag.players = "toactive";
            return View(db.Players.ToList());
		}

		public async Task<IActionResult> PlayersDetail(int? id)
		{
            
            if (id == null || db.Players == null)
			{
				return NotFound();
			}
            ViewBag.players = "toactive";
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
            ViewBag.contact = "toactive";
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
				ViewBag.ContactMsg = "Thanks For Reaching Out";

				return View();
			}
			return View(contactUs);
		}

		[HttpGet]
		public IActionResult Feedback()
		{
            ViewBag.feedbackActive = "toactive";
            if (Session.UserId != 0)
			{
				ViewBag.Name = HttpContext.Session.GetString("Name");
				return View();
			}
			return RedirectToAction("Login", "Users");
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
            ViewBag.cart = "toactive";
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