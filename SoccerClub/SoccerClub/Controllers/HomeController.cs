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
using System.Net.Http.Json;

namespace SoccerClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly SoccerClubContext _context;
        private readonly IApiHelper _apiHelper;

        public HomeController(SoccerClubContext _context, IApiHelper apiHelper)
        {
            this._context = _context;
            this._apiHelper = apiHelper;
        }
        public IActionResult TopTen()

        {

            var wcResponse = _apiHelper.TopTenScores("WC");
            wcResponse = wcResponse.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
            Root wcApiResponse = JsonConvert.DeserializeObject<Root>(wcResponse);

            var clResponse = _apiHelper.TopTenScores("SA");
            clResponse = clResponse.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
            Root clApiResponse = JsonConvert.DeserializeObject<Root>(clResponse);

            var plResponse = _apiHelper.TopTenScores("PL");
            plResponse = plResponse.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
            Root plApiResponse = JsonConvert.DeserializeObject<Root>(plResponse);

            var topTenScorersViewModel = new IndexVM
            {
                WorldCup = wcApiResponse,
                Premier = plApiResponse,
                UEFA = clApiResponse
            };
            var allTopScorers = topTenScorersViewModel.GetType().GetProperties()
            .Where(prop => prop.PropertyType == typeof(Root))
            .ToList();
            ViewBag.TopTenScores = allTopScorers;
            return View(topTenScorersViewModel);
        }
        public IActionResult Index()
        {
            ViewBag.Home = "toactive";
            //var jsonContent = _apiHelper.GetRecentUpdates();
            //jsonContent = jsonContent.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
            //var jsonObject = JObject.Parse(jsonContent);
            //var articlesArray = jsonObject["articles"].ToString();

            //List<Article> responseList = JsonConvert.DeserializeObject<List<Article>>(articlesArray);
            var UpComming = _context.Matches.Include(x => x.AwayTeam).Include(x => x.HomeTeam).Where(m => m.Date > DateTime.Now).OrderBy(m => m.Date).FirstOrDefault();

            if(UpComming != null)
            {
                ViewBag.HomeTeam = UpComming.HomeTeam.Name;
                ViewBag.AwayTeam = UpComming.AwayTeam.Name;
                ViewBag.date = UpComming.Date.ToLongTimeString();
            }
            var ViewModel = new IndexVM
            {
                match = _context.Matches.OrderByDescending(m => m.MatchId).Take(4).ToList(),
                matches = _context.Matches.OrderByDescending(m => m.MatchId).Take(5).ToList(),
                player = _context.Players.ToList(),
                team = _context.Teams.ToList(),
                product = _context.Products.ToList()
                //Articles = responseList
            };
            return View(ViewModel);
        }
        public ActionResult Search(string keyword)
        {
            ViewBag.keyword = keyword;
            var ViewModel = new IndexVM
            {
                matches = _context.Matches.Include(x => x.AwayTeam).Include(x => x.HomeTeam).Where(m => m.AwayTeam.Name.Contains(keyword) || m.HomeTeam.Name.Contains(keyword)).ToList(),
                player = _context.Players.Include(x => x.Team).Where(m => m.Name.Contains(keyword)).ToList(),
                team = _context.Teams.Where(m => m.Name.Contains(keyword)).ToList(),
                product = _context.Products.Where(m => m.ProductName.Contains(keyword)).ToList(),
            };
            return View(ViewModel);
        }
        public async Task<IActionResult> ProductDetail(int? id)
        {
            ViewBag.shop = "toactive";
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
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
            var match = _context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam).
                ToList();
            return View(match);
        }
        // GET: Matches/Details/5
        public async Task<IActionResult> MatchesDetail(int? id)
        {
            ViewBag.matches = "toactive";
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            ViewBag.MatchDetails = match;
            var HomePlayers = await _context.Players.Where(m => m.TeamId == match.HomeTeamId).ToListAsync();
            var AwayPlayers = await _context.Players.Where(m => m.TeamId == match.AwayTeamId).ToListAsync();

            var ViewModel = new IndexVM
            {
                player = (IEnumerable<Player>)HomePlayers.ToList(),
                awayplayer = (IEnumerable<Player>)AwayPlayers.ToList(),
                Match = match
            };

            return View(ViewModel);
        }
        public async Task<IActionResult> Shop()
        {
            ViewBag.shop = "toactive";
            ViewBag.CategoryId = _context.Category.ToList();
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult Schedule()
        {
            ViewBag.schedule = "toactive";
            var match = _context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam).
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
            ViewBag.pl = "toactive";
            return View(_context.Players.Include(x => x.Team).ToList());
        }
        public async Task<IActionResult> PlayersDetail(int? id)
        {

            if (id == null || _context.Players == null)
            {
                return NotFound();
            }
            ViewBag.players = "toactive";
            var player = await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(m => m.PlayerID == id);
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
                _context.contactUs.Add(contactUs);
                _context.SaveChanges();
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

                ViewBag.feedback = "";
                return View();
            }
            return RedirectToAction("Login", "Users");
        }

        [HttpPost]
        public IActionResult Feedback(Feedback feed)
        {
            feed.UserId = Session.UserId;
            _context.Feedbacks.Add(feed);
            _context.SaveChanges();
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
        public IActionResult History()
        {
            ViewBag.history = "toactive";
            return View();
        }
        public IActionResult SiteMap()
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