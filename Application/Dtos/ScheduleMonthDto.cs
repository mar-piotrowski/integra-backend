using Domain.Enums;

namespace Application.Dtos;

public record ScheduleMonthDto(Month Month, decimal TotalHours, List<ScheduleDayDto> Days);