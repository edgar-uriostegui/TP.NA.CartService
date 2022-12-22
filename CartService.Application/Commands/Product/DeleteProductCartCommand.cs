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
    public class DeleteProductCartCommand
    {
        #region Result

        public class ResultDeleteProductCart
        {
            public DeleteProductCartResponse DeleteProductCartResponse { get; set; } = new DeleteProductCartResponse();

        }

        #endregion

        #region Command

        public class CommandDeleteProductCart : ICommand<Response<ResultDeleteProductCart>>
        {
            public DeleteProductCartRequest request { get; set;}
        }

        #endregion

        #region Mapper

        #endregion

        #region Handler

        public class Handler : ICommandHandler<CommandDeleteProductCart, Response<ResultDeleteProductCart>>
        {
            private readonly IMapper _mapper;

            private readonly ICartRepository _cartRepository;

            private readonly Response<ResultDeleteProductCart> _response;

            public Handler(IMapper mapper, ICartRepository cartRepository)
            {
                _mapper = mapper;
                _cartRepository = cartRepository;
                _response = new Response<ResultDeleteProductCart>
                {
                    Payload = new ResultDeleteProductCart()
                };
            }

            public async Task<Response<ResultDeleteProductCart>> Handle(CommandDeleteProductCart request, CancellationToken cancellationToken)
            {
                try
                {
                    var carts = await _cartRepository.GetAllAsync();
                    var cart = carts.FirstOrDefault(c => c.UserId == request.request.ClientId);
                    var product = cart.Products.FirstOrDefault(c => c.Id == request.request.ProductId);
                    
                    cart.Products.Remove(product);


                    var model = _mapper.Map<CartEntity, CartModel>(cart);

                    _response.Payload.DeleteProductCartResponse.Cart = model;
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
