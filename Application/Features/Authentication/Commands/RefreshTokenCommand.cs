using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Authentication.Commands;

public record RefreshTokenCommand(string Token) : ICommand<Tokens>;