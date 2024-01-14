using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.HolidayLimit.CreateHolidayLimit;

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
        var user = _userRepository.GetInfoToCreateLimit(request.UserId);
        if (user is null)
            return Result.Failure(UserErrors.NotFound);
        if (user.HolidayLimits.Any(holidayLimit =>
                holidayLimit.StartDate.Year == DateTime.Now.Year && holidayLimit.EndDate.Year == DateTime.Now.Year))
            return Result.Failure(HolidayLimitErrors.YearExists);
        if (request.StartDate.Year != request.EndDate.Year)
            return Result.Failure(HolidayLimitErrors.WrongYear);
        var limit = _holidayCalculator.CalculateLimit(request.UserId, request.StartDate, request.EndDate);
        if (limit.IsFailure)
            return limit;
        var holidayLimit = Domain.Entities.HolidayLimit.Create(
            request.UserId,
            request.Current,
            request.StartDate,
            request.EndDate,
            limit.Value.Available,
            mergedDays: limit.Value.Merged,
            description: request.Description
        );
        _holidayLimitRepository.Add(holidayLimit);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}