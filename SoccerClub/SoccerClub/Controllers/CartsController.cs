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
        public IActionResult Cart()

        {
            if (Session.UserId != 0)
            {
                var cartItems = _context.Carts
                                .Include(p => p.product)
                                 .ThenInclude(product => product.Category)
                                .Where(x => x.UserId == Session.UserId && x.Status == true)
                                .ToList();
                Session.CartCount=cartItems.Count().ToString();
                return View(cartItems);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddToCart(Cart cart)
        {
            var product = _context.Products.Find(cart.ProductId);

            if (product != null)
            {
                if (Session.UserId != 0)
                {
                    var cartIfExist = _context.Carts.Where(x => x.UserId == Session.UserId && x.ProductId.Equals(cart.ProductId) && x.Status == true).FirstOrDefault();
                    if (cartIfExist != null)
                    {
                        var getCartItem = _context.Carts.Find(cartIfExist.CartId);
                        getCartItem.Quantity += cart.Quantity;
                        getCartItem.Price = product.Price * getCartItem.Quantity;


                        _context.Update(getCartItem);
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
            if (id == null || _context.Carts == null)
            {
                return NotFound();
            }

            var cartItem = _context.Carts.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            else
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
                return RedirectToAction("Cart");
            }
        }
        public IActionResult Checkout()
        {
            if (Session.UserId != 0)
            {
                Session.CartCount = "0";
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
                var thisOrderId = _context.Orders
                                .Where(x => x.UserId == Session.UserId)
                                .Max(x => x.OrderId);

                //_context.Carts.Update();
                //_context.SaveChanges();
                return RedirectToAction("Order", new { id = thisOrderId });
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Order(int id)
        {
            var order = _context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            if (order != null)
                return View();
            return RedirectToAction("Cart");
        }
    }
}