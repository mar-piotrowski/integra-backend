using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Card.Command;

public record CreateCardCommand(string Number, UserId UserId) : ICommand;