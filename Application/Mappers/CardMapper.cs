using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class CardMapper {
    private static readonly UserMapper UserMapper = new UserMapper();

    public static CardDto MapToDto(this Card card) => new CardDto(
        card.Number.Value,
        card.CreatedDate,
        card.IsActive,
        UserMapper.MapToDto(card.User)
    );

    public static List<CardDto> MapToDtos(this IEnumerable<Card> cards) => cards.Select(MapToDto).ToList();
}