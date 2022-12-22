namespace CartService.Application.Commands.Cart.Response
{
    using CartService.Application.Commons;
    using CartService.Application.Models;

    /// <summary>
    /// Create cart response
    /// </summary>
    public class CreateCartResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets cart model
        /// </summary>
        public CartModel Cart { get; set; }
    }
}
