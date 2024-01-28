using Application.Dtos;
using Application.Features.Schedule.CreateSchedule;
using Application.Features.Schedule.DeleteSchedule;
using Application.Features.Schedule.GetSchedule;
using Application.Features.Schedule.GetSchedules;
using Application.Features.Schedule.UpdateSchedule;
using Application.Features.User.GetSchedule;
using Application.Features.User.GetSchedules;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/schedules")]
public class ScheduleController : ControllerBase {
    private readonly ISender _sender;

    public ScheduleController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll() {
        var result = await _sender.Send(new GetSchedulesQuery());
        return result.MapResult();
    }

    [HttpGet("{scheduleId:int}")]
    public async Task<ActionResult> Get(int scheduleId) {
        var result = await _sender.Send(new GetScheduleQuery(ScheduleSchemaId.Create(scheduleId)));
        return result.MapResult();
    }
    
    [HttpGet("users/{userId:int}/{year:int}/{month:int}")]
    public async Task<ActionResult> GetUserSchedule(int userId, int year, int month, [FromQuery] bool onlyWeek) {
        var result = await _sender.Send(new GetUserScheduleQuery(UserId.Create(userId), year, month, onlyWeek));
        return result.MapResult();
    }
    
    [HttpGet("users/{year:int}/{month:int}")]
    public async Task<ActionResult> GetUsersSchedule(int year, int month, [FromQuery] bool onlyWeek) {
        var result = await _sender.Send(new GetUsersScheduleQuery(year, month, onlyWeek));
        return result.MapResult();
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateScheduleRequest request) {
        var result = await _sender.Send(new CreateScheduleCommand(
            request.Name,
            request.StartDate,
            request.EndDate,
            request.Days
        ));
        return result.MapResult();
    }

    [HttpPut("{scheduleId:int}")]
    public async Task<ActionResult> Update(int scheduleId, [FromBody] UpdateScheduleRequest request) {
        var result = await _sender.Send(new UpdateScheduleCommand(
            ScheduleSchemaId.Create(scheduleId),
            request.Name,
            request.StartDate,
            request.EndDate,
            request.Days
        ));
        return result.MapResult();
    }

    [HttpDelete("{scheduleId:int}")]
    public async Task<ActionResult> Delete(int scheduleId) {
        var result = await _sender.Send(new DeleteScheduleCommand(ScheduleSchemaId.Create(scheduleId)));
        return result.MapResult();
    }
}