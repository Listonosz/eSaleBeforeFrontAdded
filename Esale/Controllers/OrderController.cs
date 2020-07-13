using eSale.Data;
using eSale.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSale.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly eSaleDbContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(eSaleDbContext context, ShoppingCart shoppingCart, UserManager<AppUser> userManager)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
        }
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _context.Add(order);
            _context.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var OrderItem = new OrderItem
                {
                    Price = shoppingCartItem.Product.Price,
                    ProductId = shoppingCartItem.Product.ProductId,
                    OrderId = order.OrderId
                };

                _context.OrderItem.Add(OrderItem);

            }

            _context.SaveChanges();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart is empty");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);

                var products = _shoppingCart.GetShoppingCartItems();

                foreach (var item in products)
                {
                    var prodId = item.Product.ProductId;
                    var prod = _context.Products.FirstOrDefault(m => m.ProductId == prodId);
                    prod.DateSold = DateTime.Now;
                    prod.IsOnSale = false;
                    prod.CategoryId = 1;
                }
                _context.SaveChanges();

                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
           
            ViewBag.CheckoutCompleteMessage = "Dziękujemy za zamówienie, skontaktujemy się wkrótce!";
            return View();
        }
    }
}
