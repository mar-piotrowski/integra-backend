using Application.Dtos;
using Domain.Enums;
using Domain.Result;
using MediatR;

namespace Application.Features.User.Queries;

public record GetUsersQuery(SortingOrder Sort) : IRequest<Result<UsersResponse>>;
    
