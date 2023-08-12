    using Microsoft.AspNetCore.Mvc;
using SoccerClub.Data;
using SoccerClub.Models;
using System.Numerics;

namespace SoccerClub.Controllers
{
    public class CartsController : Controller
    {
        private readonly SoccerClubContext _context;
		public CartsController(SoccerClubContext context)
		{
			_context = context;
		}
        public IActionResult Index()
        {
			if (Session.UserId != 0)
			{
				var cartItems=_context.Carts.Where(x=>x.UserId == Session.UserId).ToList();
				return View(cartItems);
			}
            
            return View("Index","Home");
        }

        [HttpPost]
		public IActionResult AddToCart(Cart cart, int productId)
		{
			var product = _context.Products.Find(productId);
			if (product != null)
			{
				cart.Price = product.Price*cart.Quantity;
				_context.Carts.Add(cart);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		//public IActionResult AddToCart(int productId, int Quantity)
		//{
		//	var product = _context.Product.Find(productId); // Assuming you have a Product model

		//	if (product == null)
		//	{
		//		return NotFound();
		//	}


		//	cart.AddQuantity(productId, product.ProductName, Quantity);

		//	return RedirectToAction("Index", "Cart"); // Redirect to a relevant view
		//}




	}
}
