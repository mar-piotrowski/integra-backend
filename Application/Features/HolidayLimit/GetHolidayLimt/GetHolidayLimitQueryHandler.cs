using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.HolidayLimit.GetHolidayLimt;

public class GetHolidayLimitQueryHandler : IQueryHandler<GetHolidayLimitQuery, HolidayLimitDto> {
    private readonly IHolidayLimitRepository _holidayRepository;

    public GetHolidayLimitQueryHandler(IHolidayLimitRepository holidayRepository) {
        _holidayRepository = holidayRepository;
    }

    public async Task<Result<HolidayLimitDto>> Handle(
        GetHolidayLimitQuery request,
        CancellationToken cancellationToken
    ) {
        var holidayLimit = _holidayRepository.GetById(request.HolidayLimitId);
        return holidayLimit?.MapToDto() ?? Result.Failure<HolidayLimitDto>(HolidayLimitErrors.NotFound);
    }
}