using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Features.Card.ActiveCard;

public record ActiveCardCommand(CardNumber Number) : ICommand;