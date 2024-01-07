using Application.Dtos;
using Domain.Common.Result;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Authentication.Login;

public record LoginCommand(Email Email, Password Password) : IRequest<Result<Tokens>>;