using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Abstractions.Query
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
