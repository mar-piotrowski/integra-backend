using Application.Dtos;
using Domain.Entities;
using Domain.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;

namespace Application.Features.User.Queries;

public record GetUserQuery(UserId UserId) : IRequest<Result<UserDto>>;