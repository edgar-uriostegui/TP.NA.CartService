namespace CartService.Application.Queries.Cart.Response
{
    using CartService.Application.Commons;
    using CartService.Application.Models;

    /// <summary>
    /// Get cart by id
    /// </summary>
    public class GetCartById : BaseResponse
    {
        /// <summary>
        /// Gets or sets cart
        /// </summary>
        public CartModel Cart { get; set; }
    }
}
