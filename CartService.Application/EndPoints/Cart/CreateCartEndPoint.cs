using Carter;
using CartService.Application.Commands.Cart;
using CartService.Application.Commands.Cart.Request;
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

namespace CartService.Application.EndPoints.Cart
{
    public class CreateCartEndPoint : ICarterModule
    {
        private async Task<Response<CreateCartCommand.ResultCreateCart>> createCart(IMediator mediator, CreateCartCommand.CommandCreateCart request)
        {
            return await mediator.Send(request);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/v1/cartService/", createCart)
                .WithName("Add new cart")
                .Accepts<CreateCartCommand.CommandCreateCart>("application/json")
                .Produces<CreateCartCommand.ResultCreateCart>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
