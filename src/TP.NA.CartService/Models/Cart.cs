using System;

namespace TP.NA.CartService.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Productid { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CartCreate { get; set; }
    }
}
