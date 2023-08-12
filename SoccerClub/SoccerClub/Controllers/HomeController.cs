using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Matches()
        {
            return View();
        }

        public IActionResult MatchesDetail()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Players()
        {
            return View();
        }

        public IActionResult PlayersDetail()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Contact(ContactUs contactUs)
		{
            if(ModelState.IsValid)
            {
                db.contactUs.Add(contactUs);
                db.SaveChanges();
                ViewBag.Contact = "Your Message Sent Successfully";
                return RedirectToAction("Contact");
            }
			return View(contactUs);
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