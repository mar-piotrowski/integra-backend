using Application.Dtos;
using Application.Features.WorkingTime.EndWork;
using Application.Features.WorkingTime.StartWork;
using Domain.Common.Result;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/working-time")]
public class WorkingTimeController : ControllerBase {
    private readonly ISender _sender;

    public WorkingTimeController(ISender sender) {
        _sender = sender;
    }

    [HttpPost("start-work")]
    public async Task<ActionResult> StartWork([FromBody] RegisterWorkTimeRequest request) {
        var result = await _sender.Send(new StartWorkCommand(CardNumber.Create(request.CardNumber)));
        return result.MapToResult();
    }

    [HttpPost("end-work")]
    public async Task<ActionResult> EndWork([FromBody] RegisterWorkTimeRequest request) {
        var result = await _sender.Send(new EndWorkCommand(CardNumber.Create(request.CardNumber)));
        return result.MapToResult();
    }
}