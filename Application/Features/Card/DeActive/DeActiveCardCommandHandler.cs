using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Card.DeActiveCard;

public class DeActiveCardCommandHandler : ICommandHandler<DeActiveCardCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeActiveCardCommandHandler(
        ICardRepository cardRepository,
        IUnitOfWork unitOfWork
    ) {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeActiveCardCommand request, CancellationToken cancellationToken) {
        var card = _cardRepository.FindByCardNumber(request.Number);
        if (card is null)
            return Result.Failure(CardErrors.NotFound);
        if (!card.IsActive)
            return Result.Failure(CardErrors.AlreadyDeActive);
        card.DeActive();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}