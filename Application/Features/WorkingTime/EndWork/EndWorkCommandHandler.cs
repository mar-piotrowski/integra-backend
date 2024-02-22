using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;

namespace Application.Features.WorkingTime.EndWork;

public class EndWorkCommandHandler : ICommandHandler<EndWorkCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EndWorkCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork) {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EndWorkCommand request, CancellationToken cancellationToken) {
        var card = _cardRepository.FindByCardNumber(request.CardNumber);
        if (card is null)
            return Result.Failure(CardErrors.NotFound);
        var workStarted = card.User.WorkingTimes
            .OrderBy(workingTime => workingTime.StartDate)
            .LastOrDefault(workingTime => workingTime.Status == WorkingTimeStatus.Start);
        if (workStarted is null)
            return Result.Failure(WorkingTimeErrors.JobHasNotStarted);
        card.User.EndWork();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}