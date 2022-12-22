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
    /// Get cart by id end point
    /// </summary>
    public class GetCartByIdEndPoint : ICarterModule
    {
        private async Task<Response<GetCartByIdQuery.ResultGetCartById>> getCartById(IMediator mediator, int cartId)
        {
            var result = new GetCartByIdQuery.Query();
            result.Request.Id = cartId;

            return await mediator.Send(result);
        }

        public void AddRoutes(IEndpointRouteBuilder app)
        {
             app.MapGet("/api/v1/cartService/{cartId:int}", getCartById)
            .WithName("GetCart by id Service")
            .Produces<GetCartByIdQuery.ResultGetCartById>(StatusCodes.Status200OK);
        }
    }
}