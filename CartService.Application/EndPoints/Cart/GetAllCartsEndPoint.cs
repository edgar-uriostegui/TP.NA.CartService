namespace CartService.Application.EndPoints.Cart
{
    using Carter;
    using CartService.Application.Commons;
    using CartService.Application.Queries.Cart;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;

    /// <summary>
    /// Get all carts end point
    /// </summary>
    public class GetAllCartsEndPoint : ICarterModule
    {
        private async Task<Response<GetAllCartsQuery.ResultGetAllCarts>> getAllCarts(IMediator mediator)
        {
            return await mediator.Send(new GetAllCartsQuery.Query());
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/cartService", getAllCarts)
            .WithName("GetAllCartService")
            .Produces<GetAllCartsQuery.ResultGetAllCarts>(StatusCodes.Status200OK);
        }
    }
}