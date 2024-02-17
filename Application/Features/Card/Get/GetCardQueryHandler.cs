using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Card.GetCard;

public class GetCardQueryHandler : IQueryHandler<GetCardQuery, CardDto> {
    private readonly ICardRepository _cardRepository;
    
    public GetCardQueryHandler(ICardRepository cardRepository) {
        _cardRepository = cardRepository;
    }

    public async Task<Result<CardDto>> Handle(GetCardQuery request, CancellationToken cancellationToken) {
        var card = _cardRepository.FindByCardNumber(request.Number);
        if (card is null)
            return Result.Failure<CardDto>(CardErrors.NotFound);
        return card.MapToDto();
    }
}