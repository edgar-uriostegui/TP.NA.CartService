namespace CartService.Application.Queries.Cart.Response
{
    using CartService.Application.Commons;
    using CartService.Application.Models;

    /// <summary>
    /// Get all carts query
    /// </summary>
    public class GetAllCartsResponse : BaseResponse
    {
        /// <summary>
        /// List of carts
        /// </summary>
        public IEnumerable<CartModel> Carts { get; set; }

    }
}
