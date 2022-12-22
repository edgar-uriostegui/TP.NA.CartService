namespace CartService.Application.Queries.Cart
{
    using AutoMapper;
    using CartService.Application.Abstractions.Handlers;
    using CartService.Application.Abstractions.Query;
    using CartService.Application.Abstractions.Repository;
    using CartService.Application.Commons;
    using CartService.Application.Models;
    using CartService.Application.Queries.Cart.Request;
    using CartService.Application.Queries.Cart.Response;
    using CartService.Domain.Entities;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Get all carts query
    /// </summary>
    public class GetAllCartsQuery
    {
        #region Result

        /// <summary>
        /// Get all carts result
        /// </summary>
        public class ResultGetAllCarts
        {
            /// <summary>
            /// Gets or sets get all carts response
            /// </summary>
            public GetAllCartsResponse GetAllCartsReponse { get; set; }

            /// <summary>
            /// Create a all carts response
            /// </summary>
            public ResultGetAllCarts()
            {
                GetAllCartsReponse = new GetAllCartsResponse();
            }
        }

        #endregion Result

        #region Query

        /// <summary>
        /// Get all carts query
        /// </summary>
        public class Query : IQuery<Response<ResultGetAllCarts>>
        {
            /// <summary>
            /// Get all carts request
            /// </summary>
            public GetAllCartsRequest Request { get; set; }
        }

        #endregion Query

        #region Handler

        public class Handler : IQueryHandler<Query, Response<ResultGetAllCarts>>
        {
            private readonly IMapper _mapper;

            private readonly ICartRepository _cartRepository;

            private readonly Response<ResultGetAllCarts> _response;

            public Handler(IMapper mapper, ICartRepository cartRepository)
            {
                _mapper = mapper;
                _cartRepository = cartRepository;
                _response = new Response<ResultGetAllCarts>
                {
                    Payload = new ResultGetAllCarts()
                };
            }

            public async Task<Response<ResultGetAllCarts>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await _cartRepository.GetAllAsync();

                    _response.Payload.GetAllCartsReponse.Carts = _mapper.Map<IEnumerable<CartModel>>(result);
                }
                catch (Exception ex)
                {
                    _response.SetFailureResponse("Get all carts", $"An error was throw trying to get all the carts");
                    _response.Payload.GetAllCartsReponse.StatusCode = StatusCodes.Status500InternalServerError;
                }

                return _response;
            }
        }

        #endregion Handler
    }
}