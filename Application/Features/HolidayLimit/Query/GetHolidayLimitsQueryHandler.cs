using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.HolidayLimit.Query;

public class GetHolidayLimitsQueryHandler : IQueryHandler<GetHolidayLimitsQuery, HolidayLimitResponse> {
    private readonly IHolidayLimitRepository _holidayLimitRepository;
    private readonly IUserRepository _userRepository;

    public GetHolidayLimitsQueryHandler(
        IHolidayLimitRepository holidayLimitRepository,
        IUserRepository userRepository
    ) {
        _holidayLimitRepository = holidayLimitRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<HolidayLimitResponse>> Handle(
        GetHolidayLimitsQuery request,
        CancellationToken cancellationToken
    ) {
        var limits = _holidayLimitRepository.GetAll(UserId.Create(request.Queries.UserId));
        return !limits.Any()
            ? Result.Failure<HolidayLimitResponse>(HolidayLimitErrors.NotFoundAny)
            : Result.Success(new HolidayLimitResponse(limits.MapToDtos()));
    }
}