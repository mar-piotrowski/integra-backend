using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Authentication.RefreshToken;

public record RefreshTokenCommand(string Token) : ICommand<Tokens>;