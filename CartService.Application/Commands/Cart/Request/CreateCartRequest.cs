using CartService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commands.Cart.Request
{
    public class CreateCartRequest
    {
        public int ClientId { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
