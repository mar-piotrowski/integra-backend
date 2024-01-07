using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Card.GetCard;

public record GetCardQuery(CardNumber Number) : IQuery<CardDto>;