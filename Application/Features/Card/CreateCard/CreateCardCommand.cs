using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Card.CreateCard;

public record CreateCardCommand(UserId UserId, CardNumber Number) : ICommand;