using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Features.Card.DeActiveCard;

public record DeActiveCardCommand(CardNumber Number) : ICommand;