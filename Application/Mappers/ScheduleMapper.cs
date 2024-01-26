using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class ScheduleMapper {
    public List<ScheduleDto> MapToDtos(IEnumerable<ScheduleSchema> schedules) =>
        schedules.Select(MapToDto).ToList();

    public ScheduleDto MapToDto(ScheduleSchema schedule) => new ScheduleDto(
        schedule.Id.Value,
        schedule.Name,
        schedule.StartDate,
        schedule.EndDate,
        schedule.TotalHours,
        MapDaysToDto(schedule.Days)
    );
    
    public List<ScheduleDayDto> MapDaysToDto(IEnumerable<ScheduleSchemaDay> schemaDays) =>
        schemaDays.Select(schemaDay => new ScheduleDayDto(
            schemaDay.Day,
            schemaDay.StartHour,
            schemaDay.EndHour
        )).OrderBy(day => day.Day).ToList();
}