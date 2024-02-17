using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Card.Delete;

public class DeleteCardCommandHandler : ICommandHandler<DeleteCardCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteCardCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork) {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCardCommand request, CancellationToken cancellationToken) {
        var card = _cardRepository.FindByCardNumber(request.CardNumber);
        if (card is null)
            return Result.Failure(CardErrors.NotFound);
        card.DeActive();
        _cardRepository.Remove(card);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}