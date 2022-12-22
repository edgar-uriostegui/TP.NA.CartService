using Carter;
using CartService.Application.Commands.Product;
using CartService.Application.Commons;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.EndPoints.Product
{
    public class DeleteProductCartEndPoint : ICarterModule
    {
        private async Task<Response<DeleteProductCartCommand.ResultDeleteProductCart>> removeProductCart(IMediator mediator, DeleteProductCartCommand.CommandDeleteProductCart request)
        {
            return await mediator.Send(request);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/cartService/removeProduct", removeProductCart)
                 .WithName("Remove object from the cart")
                 .Accepts<DeleteProductCartCommand.CommandDeleteProductCart>("application/json")
                 .Produces<DeleteProductCartCommand.ResultDeleteProductCart>(StatusCodes.Status200OK)
                 .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
