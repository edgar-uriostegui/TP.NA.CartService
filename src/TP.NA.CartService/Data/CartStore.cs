using System;
using TP.NA.CartService.Models;
using TP.NA.CartService.Models.Models;

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
                UserId = 1,
                Products = new List<Product>
                {
                    new Product
                    {
                        Quantity= 1,
                        Price= 1,
                        Name = "aaaaa",
                        ID = 1
                    },
                    new Product
                    {
                        Quantity= 1,
                        Price= 1,
                        Name = "eeeee",
                        ID = 1
                    }
                }
            },
            new Cart
            {
                Id = 2,
                CartCreate = DateTime.Now,
                UserId = 2,
                Products = new List<Product>
                {
                    new Product
                    {
                        Quantity= 1,
                        Price= 1,
                        ID= 1,
                        Name = "SSSS"
                    },
                    new Product
                    {
                        Quantity= 3,
                        Name = "AAAA",
                        ID = 2,
                        Price = 11
                    }
                }
            }
        };
    }
}
