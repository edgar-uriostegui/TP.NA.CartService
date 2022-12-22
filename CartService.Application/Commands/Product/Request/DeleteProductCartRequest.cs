using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commands.Product.Request
{
    public class DeleteProductCartRequest
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }
    }
}
