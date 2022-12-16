using System;
using TP.NA.CartService.Models;

namespace TP.NA.CartService.Data
{
    public static class CartStore
    {
        public static List<Cart> LstCart = new List<Cart>
        {
            new Cart
            {
                Id = 1,
                CartCreate = DateTime.Now,
                Productid = 1,
                ProductQuantity = 1,
            },
            new Cart {
                Id = 2,
                CartCreate = DateTime.Now,
                Productid = 2,
                ProductQuantity = 10,
            }
        };
    }
}
