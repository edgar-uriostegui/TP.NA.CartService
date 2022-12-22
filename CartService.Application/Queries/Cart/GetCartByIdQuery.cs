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
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Get cart by id query
    /// </summary>
    public class GetCartByIdQuery
    {
        #region Result

        /// <summary>
        /// Get cart by id result
        /// </summary>
        public class ResultGetCartById
        {
            /// <summary>
            /// Gets or sets cart by id response
            /// </summary>
            public GetCartByIdResponse GetCartByIdResponse { get; set; }

            /// <summary>
            /// Create a new result
            /// </summary>
            public ResultGetCartById()
            {
                GetCartByIdResponse = new GetCartByIdResponse();
            }
        }

        #endregion Result

        #region Query

        /// <summary>
        /// Get cart by id query class
        /// </summary>
        public class Query : IQuery<Response<ResultGetCartById>>
        {
            /// <summary>
            /// Gets or sets get cart by id request
            /// </summary>
            public GetCartByIdRequest Request { get; set; } = new GetCartByIdRequest();
        }

        #endregion Query

        #region Handler

        /// <summary>
        /// Get cart by id handler
        /// </summary>
        public class Handler : IQueryHandler<Query, Response<ResultGetCartById>>
        {
            private readonly IMapper _mapper;

            private readonly ICartRepository _cartRepository;

            private readonly Response<ResultGetCartById> _response;

            public Handler(IMapper mapper, ICartRepository cartRepository)
            {
                _mapper = mapper;
                _cartRepository = cartRepository;
                _response = new Response<ResultGetCartById>
                {
                    Payload = new ResultGetCartById()
                };
            }

            public async Task<Response<ResultGetCartById>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = await _cartRepository.GetByIdAsync(request.Request.Id);

                    _response.Payload.GetCartByIdResponse.Cart = _mapper.Map<CartModel>(result);
                }
                catch (Exception ex)
                {
                    _response.SetFailureResponse("Get cart by id", $"An error was throw trying to the specific cart");
                    _response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                return _response;
            }
        }

        #endregion Handler
    }
}