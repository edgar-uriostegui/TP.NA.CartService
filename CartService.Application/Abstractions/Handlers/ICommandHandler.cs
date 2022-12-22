namespace CartService.Application.Abstractions.Handlers
{
    using CartService.Application.Abstractions.Command;
    using MediatR;

    internal interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
}
