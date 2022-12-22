
using AutoMapper;
using Carter;
using CartService.Application.Abstractions.Repository;
using CartService.Application.Commons;
using CartService.Application.Models;
using CartService.Application.Queries.Cart;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace CartService.Application.EndPoints.Cart
{
    /// <summary>
    /// Get all carts end point
    /// </summary>
    public class GetAllCartsEndPoint : ICarterModule
    {
        private async Task<Response<GetAllCartsQuery.Result>> getAllCarts(IMediator mediator)
        {


            return  await mediator.Send(new GetAllCartsQuery.Query());
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/cartService", getAllCarts)
            .WithName("GetCartService");
        }
    }
}
