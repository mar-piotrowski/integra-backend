using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Authentication.ChangePassword;

public record ChangePasswordCommand(UserId UserId, string CurrentPassword, string NewPassword) : ICommand;