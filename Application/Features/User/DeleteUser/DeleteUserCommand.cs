using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.DeleteUser;

public record DeleteUserCommand(UserId Id) : IRequest<Result>;