using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.HolidayLimit.Command;

public class CreateHolidayLimitCommandHandler : ICommandHandler<CreateHolidayLimitCommand> {
    private readonly IHolidayLimitRepository _holidayLimitRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHolidayCalculator _holidayCalculator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateHolidayLimitCommandHandler(
        IHolidayLimitRepository holidayLimitRepository,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IHolidayCalculator holidayCalculator
    ) {
        _holidayLimitRepository = holidayLimitRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _holidayCalculator = holidayCalculator;
    }

    public async Task<Result> Handle(CreateHolidayLimitCommand request, CancellationToken cancellationToken) {
        if (_userRepository.GetById(request.UserId) is null)
            return Result.Failure(UserErrors.NotFound);
        if (request.StartDate.Year != request.EndDate.Year)
            return Result.Failure(HolidayLimitErrors.WrongYear);
        if (_holidayLimitRepository.GetByYear(request.StartDate, request.EndDate) is not null)
            return Result.Failure(HolidayLimitErrors.YearExists);
        var limit = _holidayCalculator.CalculateLimit(request.UserId, request.StartDate, request.EndDate);
        var holidayLimit = Domain.Entities.HolidayLimit.Create(
            request.UserId,
            request.Current,
            request.StartDate,
            request.EndDate,
            limit.Available,
            mergedDays: limit.Merged,
            description: request.Description
        );
        _holidayLimitRepository.Add(holidayLimit);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}