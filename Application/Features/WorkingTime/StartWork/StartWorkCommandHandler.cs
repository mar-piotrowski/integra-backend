using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;
using Domain.Enums;
using Domain.Utils;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Application.Features.WorkingTime.StartWork;

public class StartWorkCommandHandler : ICommandHandler<StartWorkCommand> {
    private readonly ICardRepository _cardRepository;
    private readonly IWorkingTimeRepository _workingTimeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StartWorkCommandHandler(
        ICardRepository cardRepository,
        IUnitOfWork unitOfWork,
        IWorkingTimeRepository workingTimeRepository
    ) {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
        _workingTimeRepository = workingTimeRepository;
    }

    public async Task<Result> Handle(StartWorkCommand request, CancellationToken cancellationToken) {
        var card = _cardRepository.FindByCardNumber(request.CardNumber);
        if (card is null)
            return Result.Failure(CardErrors.NotFound);
        var workStarted = card.User.WorkingTimes
            .OrderBy(workingTime => workingTime.StartDate)
            .LastOrDefault(workingTime => workingTime.Status == WorkingTimeStatus.Start);
        if (workStarted is not null)
            return Result.Failure(WorkingTimeErrors.JobAlreadyStarted);
        var workingTime = new Domain.Entities.WorkingTime();
        workingTime.StartWork();
        _workingTimeRepository.Add(workingTime);
        card.User.StartWork(workingTime);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}