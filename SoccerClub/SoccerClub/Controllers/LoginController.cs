using Microsoft.AspNetCore.Mvc;
using SoccerClub.Data;

namespace SoccerClub.Controllers
{
    public class LoginController : Controller
    {
        private readonly SoccerClubContext _context;

        public LoginController(SoccerClubContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }
        
        //public IActionResult Login()
        //{
        //    return View();
            
        //}
    }
}
