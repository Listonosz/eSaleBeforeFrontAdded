using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSale.Data;
using eSale.Models;
using eSale.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eSale.Controllersd
{
    public class ShoppingCartController : Controller
    {
        private readonly eSaleDbContext _context;

        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(eSaleDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int ProductId)
        {
            var selectedProduct = _context.Products.FirstOrDefault(c => c.ProductId == ProductId);

            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int ProductId)
        {
            var selectedProduct = _context.Products.FirstOrDefault(c => c.ProductId == ProductId);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}