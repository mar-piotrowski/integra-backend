using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Card.GetCards;

public class GetCardsQueryHandler : IQueryHandler<GetCardsQuery, CardsResponse> {
    private readonly ICardRepository _cardRepository;
    
    public GetCardsQueryHandler(ICardRepository cardRepository) {
        _cardRepository = cardRepository;
    }

    public async Task<Result<CardsResponse>> Handle(GetCardsQuery request, CancellationToken cancellationToken) {
        var cards = _cardRepository.GetAll().ToList();
        if (!cards.Any())
            return Result.Failure<CardsResponse>(CardErrors.NotFoundAny);
        return Result.Success(new CardsResponse(cards.MapToDtos()));
    }
}