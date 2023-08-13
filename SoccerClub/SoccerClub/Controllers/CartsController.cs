using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Cart(int? cartid)
        
        {
            if (Session.UserId != 0)
            {
                var cartItems = _context.Carts
                                .Include(p => p.product)
                                 .ThenInclude(product => product.Category)
                                .Where(x => x.UserId == Session.UserId&&x.Status==true)
                                .ToList();
                return View(cartItems);
            }

            return View("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddToCart(Cart cart)
        {
            var product = _context.Products.Find(cart.ProductId);

            if (product != null)
            {
                if (Session.UserId != 0)
                {
                    var cartIfExist = _context.Carts.Where(x => x.UserId == Session.UserId && x.ProductId.Equals(cart.ProductId)&&x.Status==true).FirstOrDefault();
                    if (cartIfExist != null)
                    {
                        var getCartItem = _context.Carts.Find(cartIfExist.CartId);
                        cart= getCartItem != null ? getCartItem : cart;
                        cart.Quantity += getCartItem.Quantity;
                        cart.Price = product.Price * cart.Quantity;
                        _context.Update(cart);
                        _context.SaveChanges();
                        return RedirectToAction("Cart");

                    }
                    else
                    {
                        cart.UserId = Session.UserId;
                        cart.Price = product.Price * cart.Quantity;
                        _context.Carts.Add(cart);
                        _context.SaveChanges();
                        return RedirectToAction("Cart", "Carts");
                    }
                    
                }

                return RedirectToAction("Login", "Users");
            }
            return RedirectToAction("ProductDetail", "Home");
        }

        public IActionResult DelItem(int id)
        {
            return View();
        }
        public IActionResult Checkout()
        {
            if(Session.UserId != 0)
            {
                Order order = new Order();
                int totalAmount = 0;
                var cartdata = _context.Carts.Include(p => p.product).Include(u => u.User).Where(x => x.UserId.Equals(Session.UserId) && x.Status == true).ToList();
                foreach (var item in cartdata)
                {
                    totalAmount += item.Price;
                    item.Status = false;

                    _context.Carts.Update(item);
                    _context.SaveChanges();
                }
                order.UserId = Session.UserId;
                order.OrderDate = DateTime.Now;
                order.TotalPrice = totalAmount;

                  _context.Orders.Add(order);
                  _context.SaveChanges();
        
                //_context.Carts.Update();
                //_context.SaveChanges();
                return RedirectToAction("Order");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
