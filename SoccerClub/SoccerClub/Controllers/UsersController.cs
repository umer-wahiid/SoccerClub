using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Data;
using SoccerClub.Models;

namespace SoccerClub.Controllers
{
    public class UsersController : Controller
    {
        private readonly SoccerClubContext _context;

        public UsersController(SoccerClubContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.ToListAsync()) :
                          Problem("Entity set 'SoccerClubContext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        // GET: Users/Details/5
        public async Task<IActionResult> UserDetails(int? id)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Register()
        {
			if (Session.UserId != 0)
			{
				if (Session.IsAdmin == "Yes")
				{

					return RedirectToAction("Index", "admin");
				}
				return RedirectToAction("Index", "Home");

			}
			return View();
        }

        public IActionResult Login()
        {
            if (Session.UserId != 0)
			{
				if (Session.IsAdmin == "Yes")
				{

					return RedirectToAction("Index", "admin");
				}
				return RedirectToAction("Index", "Home");
               
            }
            return View();
        }


		[HttpPost]
		public IActionResult Login(User user)
		{
			if (Session.UserId == 0)
			{
				var userByPassword = _context.User.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
				if (userByPassword != null)
				{
					HttpContext.Session.SetInt32("UserId", userByPassword.UserId);

					if (userByPassword.IsAdmin)
					{
						HttpContext.Session.SetString("IsAdmin", "Yes");
						Session.UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
						Session.IsAdmin = HttpContext.Session.GetString("IsAdmin") ?? "NO";
						return RedirectToAction("Index", "admin");

					}
					Session.UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
					return RedirectToAction("Index", "Home");


				}

				ViewBag.err = "Incorrect Password or Email";
				return View(user);
			}
			return View("Index", "Home");
		}

		public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Session.UserId = 0;
            Session.IsAdmin = "No";
            return RedirectToAction("Index", "Home");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
			if (Session.UserId == 0)
			{
				if (ModelState.IsValid)
				{
					_context.Add(user);
					await _context.SaveChangesAsync();
					return RedirectToAction("Login");
				}
				return View(user);
			}
			return View("Index", "Home");
		}
        // GET: Users/Edit/5
        public async Task<IActionResult> UserEdit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email,Password,ConfirmPassword,PhoneNo,FullName")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(int id, [Bind("UserId,Username,Email,Address,Password,ConfirmPassword,PhoneNo,FullName")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Home");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'SoccerClubContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            Logout();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
