using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SoccerClub.Data;
using SoccerClub.Models;

namespace SoccerClub.Controllers
{
    public class TeamsController : Controller
    {
        private readonly SoccerClubContext _context;
        private readonly IWebHostEnvironment _environment;

        public TeamsController(SoccerClubContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            return _context.Teams != null ?
                        View(await _context.Teams.ToListAsync()) :
                        Problem("Entity set 'SoccerClubContext.Teams'  is null.");
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team, IFormFile ImageUrl)
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
                    team.LogoUrl = $"/Images/{fname}";
                    
                        _context.Add(team);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Teams","admin");

                }
                else
                {
                    ViewBag.m = "Wrong Picture Format";
                }
            }
            return View();
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Team team, IFormFile ImageUrl)
        {
            if (id != team.TeamId)
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
                    team.LogoUrl = $"/Images/{fname}";

                    _context.Update(team);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Teams", "admin");


                }
                else
                {
                    ViewBag.m = "Wrong Picture Format";
                }
            }


            return View();
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teams == null)
            {
                return Problem("Entity set 'SoccerClubContext.Teams'  is null.");
            }
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Teams", "admin");
        }

        private bool TeamExists(int id)
        {
            return (_context.Teams?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
    }
}
