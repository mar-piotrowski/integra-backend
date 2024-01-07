using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Authentication.Register;

public record RegisterCommand(
    string Firstname,
    string Lastname,
    Email Email,
    Password Password,
    Password ConfirmPassword
) : ICommand<TokenResponse>;