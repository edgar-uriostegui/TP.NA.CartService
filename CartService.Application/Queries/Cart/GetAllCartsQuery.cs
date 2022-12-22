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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Queries.Cart
{
    public class GetAllCartsQuery
    {
        #region Result

        /// <summary>
        /// Get all carts result
        /// </summary>
        public class Result
        {
            /// <summary>
            /// Gets or sets get all carts response
            /// </summary>
            public GetAllCartsResponse GetAllCartsReponse  { get; set; }

            /// <summary>
            /// Create a all carts response
            /// </summary>
            public Result()
            {
                GetAllCartsReponse = new GetAllCartsResponse();
            }

        }

        #endregion

        #region Query

        /// <summary>
        /// Get all carts query
        /// </summary>
        public class Query : IQuery<Response<Result>>
        {
            /// <summary>
            /// Get all carts request
            /// </summary>
            public GetAllCartsRequest Request { get; set; }
        }

        #endregion

        #region Mapper

        /// <summary>
        /// Mapper class
        /// </summary>
        public class Mapping : Profile
        {
            /// <summary>
            /// Create a mapper class
            /// </summary>
            public Mapping()
            {

                //CreateMap<List<ProductEntity>, List<ProductModel>>().ReverseMap();
                //CreateMap<CartEntity, CartModel>().ReverseMap();
                CreateMap<ProductEntity, ProductModel>().ReverseMap();
                CreateMap<CartEntity, CartModel>().ReverseMap();
               
            }
        }

        #endregion

        #region Handler

        public class Handler : IQueryHandler<Query, Response<Result>>
        {

            private readonly IMapper _mapper;

            private readonly ICartRepository _cartRepository;

            private readonly Response<Result> _response;

            public Handler(IMapper mapper, ICartRepository cartRepository)
            {
                _mapper = mapper;
                _cartRepository = cartRepository;
                _response = new Response<Result>
                {
                    Payload = new Result()
                };
            }

            public async Task<Response<Result>> Handle(Query request, CancellationToken cancellationToken)
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


        #endregion

    }
}
