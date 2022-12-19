using System;

namespace TP.NA.CartService.Models.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public DateTime CartCreate { get; set; }

        public int UserId { get; set; }
    }
}
