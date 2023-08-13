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
    public class MatchesController : Controller
    {
        private readonly SoccerClubContext _context;

        public MatchesController(SoccerClubContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var soccerClubContext = _context.Matches.Include(m => m.AwayTeam).Include(m => m.HomeTeam);
            return View(await soccerClubContext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "Country");
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "Country");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Match match)
        {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction("Matches","admin");

            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "Name", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "Country", match.HomeTeamId);

        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "Name", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "Name", match.HomeTeamId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Match match)
        {
            if (id != match.MatchId)
            {
                return NotFound();
            }

                    _context.Update(match);
                    await _context.SaveChangesAsync();
                return RedirectToAction("Matches","admin");
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matches == null)
            {
                return Problem("Entity set 'SoccerClubContext.Matches'  is null.");
            }
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                _context.Matches.Remove(match);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
          return (_context.Matches?.Any(e => e.MatchId == id)).GetValueOrDefault();
        }
    }
}
