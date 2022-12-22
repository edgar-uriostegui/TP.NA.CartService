using AutoMapper;
using CartService.Application.Abstractions.Command;
using CartService.Application.Abstractions.Handlers;
using CartService.Application.Abstractions.Repository;
using CartService.Application.Commands.Cart.Request;
using CartService.Application.Commands.Cart.Response;
using CartService.Application.Commons;
using CartService.Application.Models;
using CartService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commands.Cart
{
    /// <summary>
    /// Create cart command
    /// </summary>
    public class CreateCartCommand
    {
        #region Result

        public class ResultCreateCart
        {
            public CreateCartResponse CreateCartResponse { get; set; } = new CreateCartResponse();

        }

        #endregion

        #region Command

        /// <summary>
        /// Command
        /// </summary>
        public class CommandCreateCart : ICommand<Response<ResultCreateCart>>
        {
            public CreateCartRequest Request { get; set; }
        }

        #endregion

        #region Mapper

        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<CommandCreateCart, CartEntity>()
                    .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.Request.ClientId))
                    .ForMember(dest => dest.Products, act => act.MapFrom(src => src.Request.Products))
                    .ReverseMap();
            }
        }

        #endregion

        #region Handler

        public class Handler : ICommandHandler<CommandCreateCart, Response<ResultCreateCart>>
        {
            private readonly IMapper _mapper;

            private readonly ICartRepository _cartRepository;

            private readonly Response<ResultCreateCart> _response;

            public Handler(IMapper mapper, ICartRepository cartRepository)
            {
                _mapper = mapper;
                _cartRepository = cartRepository;
                _response = new Response<ResultCreateCart>
                {
                    Payload = new ResultCreateCart()
                };
            }

            public async Task<Response<ResultCreateCart>> Handle(CommandCreateCart request, CancellationToken cancellationToken)
            {
                try
                {
                    var map = _mapper.Map<CommandCreateCart, CartEntity>(request);

                    var result = await _cartRepository.AddAsync(map);
                    var model = _mapper.Map<CartEntity, CartModel>(result);

                    _response.Payload.CreateCartResponse.Cart = model;
                }
                catch (Exception)
                {
                    _response.SetFailureResponse("Get all carts", $"An error was throw trying to get all the carts");
                    _response.Payload.CreateCartResponse.StatusCode = StatusCodes.Status500InternalServerError;
                }

                return _response;
            }
        }

        #endregion
    }
}
