using CartService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Repository.Cart
{
    public static class CartMemoryFactory
    {
        public static List<CartEntity> listCart = new List<CartEntity>
       {
            new CartEntity
            {
                Id = 1,
                CreatedTime = DateTime.Now,
                UserId = 1,
                Products = new List<ProductEntity>
                {
                    new ProductEntity
                    {
                        Quantity= 1,
                        Cost= 1,
                        Name = "aaaaa",
                        Id = 1
                    },
                    new ProductEntity
                    {
                        Quantity= 1,
                        Cost= 1,
                        Name = "eeeee",
                        Id = 1
                    }
                }
            },
            new CartEntity
            {
                Id = 2,
                CreatedTime = DateTime.Now,
                UserId = 2,
                Products = new List<ProductEntity>
                {
                    new ProductEntity
                    {
                        Quantity= 1,
                        Cost= 1,
                        Id= 1,
                        Name = "SSSS"
                    },
                    new ProductEntity
                    {
                        Quantity= 3,
                        Name = "AAAA",
                        Id = 2,
                        Cost = 11
                    }
                }
            }
        };
    }
}
