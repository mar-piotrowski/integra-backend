using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.HolidayLimit.Query; 

public record GetHolidayLimitQuery(HolidayLimitId HolidayLimitId) : IQuery<HolidayLimitDto>;