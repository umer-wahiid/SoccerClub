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
    public class PlayersController : Controller
    {
        private readonly SoccerClubContext _context;
        private readonly IWebHostEnvironment _environment;

        public PlayersController(SoccerClubContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            var soccerClubContext = _context.Players.Include(p => p.Team);
            return View(await soccerClubContext.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Country");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player,IFormFile ImageUrl)
        {
            if (ImageUrl != null)
            {
                string ext = Path.GetExtension(ImageUrl.FileName);
                if (ext == ".jpg" || ext == "gif" || ext == ".png")
                {
                    string d = Path.Combine(_environment.WebRootPath, "Images");
                    var fname = Path.GetFileName(ImageUrl.FileName);
                    string filePath = Path.Combine(d, fname);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(fs);
                    }
                    player.PlayerImage = $"/Images/{fname}";
                        _context.Add(player);
                        await _context.SaveChangesAsync();

                    return RedirectToAction("Players","admin");
                }
                else
                {
                    ViewBag.m = "Wrong Picture Format";
                }
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Country", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Country", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Player player, IFormFile ImageUrl)
        {
            if (id != player.PlayerID)
            {
                return NotFound();
            }

            if (ImageUrl != null)
            {
                string ext = Path.GetExtension(ImageUrl.FileName);
                if (ext == ".jpg" || ext == "gif" || ext == ".png")
                {
                    string d = Path.Combine(_environment.WebRootPath, "Images");
                    var fname = Path.GetFileName(ImageUrl.FileName);
                    string filePath = Path.Combine(d, fname);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(fs);
                    }
                    player.PlayerImage = $"/Images/{fname}";
                    _context.Update(player);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Players", "admin");
                }
                else
                {
                    ViewBag.m = "Wrong Picture Format";
                }
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Country", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Players == null)
            {
                return Problem("Entity set 'SoccerClubContext.Players'  is null.");
            }
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
          return (_context.Players?.Any(e => e.PlayerID == id)).GetValueOrDefault();
        }
    }
}
