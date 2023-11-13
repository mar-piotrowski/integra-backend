using Domain.Result;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface IQueryHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : class, IRequest<Result<TResponse>> { }