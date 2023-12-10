using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.HolidayLimit.Query; 

public record GetHolidayLimitsQuery(HolidayLimitsQueries Queries) : IQuery<HolidayLimitResponse>;