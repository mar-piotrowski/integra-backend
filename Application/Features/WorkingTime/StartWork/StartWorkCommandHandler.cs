using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.WorkingTime.StartWork;

public class StartWorkCommandHandler : ICommandHandler<StartWorkCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public StartWorkCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork) {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(StartWorkCommand request, CancellationToken cancellationToken) {
        var card = _cardRepository.FindByCardNumber(request.CardNumber);
        if (card is null)
            return Result.Failure(CardErrors.NotFound);
        var workTime = new Domain.Entities.WorkingTime();
        workTime.StartWork();
        card.User.StartWork(card.User, workTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}