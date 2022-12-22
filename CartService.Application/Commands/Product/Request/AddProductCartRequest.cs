using CartService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commands.Product.Request
{
    public class AddProductCartRequest
    {
        public int ClientId { get; set; }

        public ProductModel Product { get; set; }
    }
}
