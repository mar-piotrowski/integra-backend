using Application.Dtos;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.GetUser;

public record GetUserQuery(UserId UserId) : IRequest<Result<UserDto>>;