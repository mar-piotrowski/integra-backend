using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Features.Card.Delete;

public record DeleteCardCommand(CardNumber CardNumber) : ICommand;