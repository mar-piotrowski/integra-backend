using Application.Dtos;
using Domain.Result;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Authentication.Commands;

public record LoginCommand(Email Email, Password Password) : IRequest<Result<LoginResponse>>;