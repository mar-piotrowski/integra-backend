using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.StartWork;

public record StartWorkUserCommand(UserId UserId, string CardNumber) : ICommand;