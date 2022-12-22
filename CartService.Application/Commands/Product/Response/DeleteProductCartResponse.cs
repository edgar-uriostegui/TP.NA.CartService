using CartService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commands.Product.Response
{
    public class DeleteProductCartResponse
    {
        public CartModel Cart { get; set; }
    }
}
