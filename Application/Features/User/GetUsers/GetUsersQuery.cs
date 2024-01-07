using Application.Dtos;
using Domain.Common.Result;
using Domain.Enums;
using MediatR;

namespace Application.Features.User.GetUsers;

public record GetUsersQuery(SortingOrder Sort) : IRequest<Result<UsersResponse>>;
    
