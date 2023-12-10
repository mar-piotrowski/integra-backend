using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers; 

public static class HolidayLimitMapper {
    public static HolidayLimitDto MapToDto(this HolidayLimit holidayLimit) => new HolidayLimitDto(
        holidayLimit.Id.Value,
        holidayLimit.Current,
        holidayLimit.StartDate,
        holidayLimit.EndDate,
        holidayLimit.AvailableDays,
        holidayLimit.UsedDays,
        holidayLimit.MergedDays,
        holidayLimit.Description
    );

    public static List<HolidayLimitDto> MapToDtos(this IList<HolidayLimit> holidayLimits) =>
        holidayLimits.Select(holidayLimit => holidayLimit.MapToDto()).ToList();
}