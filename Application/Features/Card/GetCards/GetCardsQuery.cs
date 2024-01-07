using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Card.GetCards;

public record GetCardsQuery : IQuery<CardsResponse>;