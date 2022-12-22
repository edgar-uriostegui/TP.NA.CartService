using AutoMapper;
using CartService.Application.Abstractions.Command;
using CartService.Application.Abstractions.Handlers;
using CartService.Application.Abstractions.Repository;
using CartService.Application.Commands.Product.Request;
using CartService.Application.Commands.Product.Response;
using CartService.Application.Commons;
using CartService.Application.Models;
using CartService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commands.Product
{
    public class AddProductCartCommand
    {
        #region Result 

        public class ResultAddProductCart
        {
            public AddProductCartResponse AddProductCartResponse { get; set; } = new AddProductCartResponse();
        }

        #endregion

        #region Command

        public class CommandAddProductCart : ICommand<Response<ResultAddProductCart>>
        {
            public AddProductCartRequest request { get; set; }
        }

        #endregion

        #region Mapper

        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<CommandAddProductCart, CartEntity>()
                    .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.request.ClientId))
                    .ReverseMap();
            }
        }

        #endregion

        #region Handler

        public class Handler : ICommandHandler<CommandAddProductCart, Response<ResultAddProductCart>>
        {
            private readonly IMapper _mapper;

            private readonly ICartRepository _cartRepository;

            private readonly Response<ResultAddProductCart> _response;

            public Handler(IMapper mapper, ICartRepository cartRepository)
            {
                _mapper = mapper;
                _cartRepository = cartRepository;
                _response = new Response<ResultAddProductCart>
                {
                    Payload = new ResultAddProductCart()
                };
            }

            public async Task<Response<ResultAddProductCart>> Handle(CommandAddProductCart request, CancellationToken cancellationToken)
            {
                try
                {
                    var carts = await _cartRepository.GetAllAsync();
                    var cart = carts.FirstOrDefault(c => c.UserId == request.request.ClientId);
                    var map = _mapper.Map<ProductModel, ProductEntity>(request.request.Product);

                    cart.Products.Add(map);

                    var model = _mapper.Map<CartEntity, CartModel>(cart);

                    _response.Payload.AddProductCartResponse.Cart = model;
                }
                catch (Exception)
                {
                    _response.SetFailureResponse("Get all carts", $"An error was throw trying to get all the carts");
                    _response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                return _response;
            }
        }

        #endregion

    }
}
