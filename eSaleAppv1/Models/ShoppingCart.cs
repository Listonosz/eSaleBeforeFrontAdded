using eSale.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSale.Models
{
    public class ShoppingCart
    {
        private readonly eSaleDbContext _eSaleDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(eSaleDbContext shopContext)
        {
            _eSaleDbContext = shopContext;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<eSaleDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product Product)
        {
            var shoppingCartItem = _eSaleDbContext.ShoppingCartItems.SingleOrDefault(
                 s => s.Product.ProductId == Product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = Product
                };
                _eSaleDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                //
            }

            _eSaleDbContext.SaveChanges();
        }

        public void RemoveFromCart(Product Product)
        {
            var shoppingCartItem = _eSaleDbContext.ShoppingCartItems.SingleOrDefault(
                 s => s.Product.ProductId == Product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {

               _eSaleDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _eSaleDbContext.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _eSaleDbContext.ShoppingCartItems.Where
                (c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Product)
                .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _eSaleDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);

            _eSaleDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _eSaleDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _eSaleDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price).Sum();
            return total;
        }
    }
}
