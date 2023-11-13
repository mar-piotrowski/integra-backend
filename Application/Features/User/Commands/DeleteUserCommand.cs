using Domain.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.Commands;

public record DeleteUserCommand(UserId Id) : IRequest<Result>;