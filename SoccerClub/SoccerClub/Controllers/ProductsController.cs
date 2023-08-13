using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SoccerClub.Data;
using SoccerClub.Models;

namespace SoccerClub.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SoccerClubContext _context;
		private readonly IWebHostEnvironment _environment;

		public ProductsController(SoccerClubContext context,IWebHostEnvironment webHost)
        {
            this._context = context;
            this._environment = webHost;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryId = _context.Category.ToList();
            return View(await _context.Products.ToListAsync());
            //return View();
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile ImageUrl) 
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
					product.ImageUrl = @"\Images\" + fname;
					_context.Add(product);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.m = "Wrong Picture Format";
				}
			}
			return View();
		}

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product  ,IFormFile ImageUrl)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
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
                            product.ImageUrl = @"\Images\" + fname;
                            _context.Update(product);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            ViewBag.m = "Wrong Picture Format";
                        }
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View();
            }
            //ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'SoccerClubContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
        //public async Task<IActionResult> Cart(int id)
        //{
        //    var product = _context.Products.Find(id); // Assuming "Products" is your DbSet in the context
        //    if (product != null)
        //    {
        //        Carts cartItem = new Carts();

        //        cartItem.ProductId = product.Productid; // Make sure "Productid" is the correct property name
        //        cartItem.ProductName = product.ProductName; // Assuming "ProductName" is a property in the "Cart" entity
        //        cartItem.Price = product.Price;
        //        cartItem.Quantity = 1;

        //        _context.Carts.Add(cartItem);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Cart");
        //    }

        //    return RedirectToAction("Index");
        //}

    }
}
