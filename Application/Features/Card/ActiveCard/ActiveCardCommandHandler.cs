using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Card.ActiveCard;

public class ActiveCardCommandHandler : ICommandHandler<ActiveCardCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActiveCardCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork) {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ActiveCardCommand request, CancellationToken cancellationToken) {
        var card = _cardRepository.GetByNumber(request.Number);
        if (card is null)
            return Result.Failure(CardErrors.NotFound);
        if (card.IsActive)
            return Result.Failure(CardErrors.AlreadyActive);
        card.Active();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}