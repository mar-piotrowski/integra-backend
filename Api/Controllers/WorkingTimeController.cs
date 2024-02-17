using Application.Dtos;
using Application.Features.WorkingTime.Delete;
using Application.Features.WorkingTime.Edit;
using Application.Features.WorkingTime.EndWork;
using Application.Features.WorkingTime.GetAll;
using Application.Features.WorkingTime.StartWork;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace IntegraBackend.Controllers;

[Route("integra/working-times")]
public class WorkingTimeController : ControllerBase {
    private readonly ISender _sender;

    public WorkingTimeController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult> GetWorkingHours([FromQuery] int? userId = null) {
        var result = await _sender.Send(new GetWorkingTimesQuery(
            userId is null ? null : UserId.Create(userId.Value)
        ));
        return result.MapToResult();
    }

    [HttpPost("users/start-work")]
    public async Task<ActionResult> StartWork([FromBody] RegisterWorkTimeRequest request) {
        var result = await _sender.Send(new StartWorkCommand(CardNumber.Create(request.CardNumber)));
        return result.MapToResult();
    }

    [HttpPost("users/end-work")]
    public async Task<ActionResult> EndWork([FromBody] RegisterWorkTimeRequest request) {
        var result = await _sender.Send(new EndWorkCommand(CardNumber.Create(request.CardNumber)));
        return result.MapToResult();
    }

    [HttpPut("{workingTimeId:int}")]
    public async Task<ActionResult> Edit(int workingTimeId, [FromBody] EditWorkingTimeRequest request) {
        var result = await _sender.Send(new EditWorkingTimeCommand(
            WorkingTimeId.Create(workingTimeId),
            request.StartDate, 
            request.EndDate
        ));
        return result.MapToResult();
    }

    [HttpDelete("{workingTimeId:int}")]
    public async Task<ActionResult> Delete(int workingTimeId) {
        var result = await _sender.Send(new DeleteWorkingTimeCommand(WorkingTimeId.Create(workingTimeId)));
        return result.MapToResult();
    }
}