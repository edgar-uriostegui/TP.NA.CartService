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
    public class AddProductCartEndPoint : ICarterModule
    {
        private async Task<Response<AddProductCartCommand.ResultAddProductCart>> addProductCart(IMediator mediator, AddProductCartCommand.CommandAddProductCart request)
        {
            return await mediator.Send(request);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/cartService/addProduct", addProductCart)
                 .WithName("Add object to cart")
                 .Accepts<AddProductCartCommand.CommandAddProductCart>("application/json")
                 .Produces<AddProductCartCommand.ResultAddProductCart>(StatusCodes.Status200OK)
                 .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
