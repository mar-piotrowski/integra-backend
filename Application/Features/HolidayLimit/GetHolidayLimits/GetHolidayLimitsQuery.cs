using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.HolidayLimit.GetHolidayLimits; 

public record GetHolidayLimitsQuery(HolidayLimitsQueries Queries) : IQuery<HolidayLimitResponse>;