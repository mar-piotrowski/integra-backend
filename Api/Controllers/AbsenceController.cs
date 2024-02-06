using Application.Dtos;
using Application.Features.Absence.Accept;
using Application.Features.Absence.Create;
using Application.Features.Absence.Delete;
using Application.Features.Absence.Get;
using Application.Features.Absence.GetAll;
using Application.Features.Absence.Reject;
using Application.Features.Absence.Update;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/absences")]
public class AbsenceController : Controller {
    private readonly ISender _sender;

    public AbsenceController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] int? userId) {
        var result = await _sender.Send(new GetAbsencesQuery(userId is null ? null : UserId.Create(userId.Value)));
        return result.MapToResult();
    }

    [HttpGet("{absenceId:int}")]
    public async Task<ActionResult> Get(int absenceId) {
        var result = await _sender.Send(new GetAbsenceQuery(AbsenceId.Create(absenceId)));
        return result.MapToResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAbsenceCommand command) {
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpPut("{absenceId:int}")]
    public async Task<ActionResult> Update(int absenceId, [FromBody] UpdateAbsenceRequest request) {
        var result = await _sender.Send(new UpdateAbsenceCommand(
            AbsenceId.Create(absenceId),
            request.StartDate,
            request.EndDate,
            request.DiseaseCode,
            request.Series,
            request.Number,
            request.Description,
           UserId.Create(request.UserId)
        ));
        return result.MapToResult();
    }

    [HttpDelete("{absenceId:int}")]
    public async Task<ActionResult> Delete(int absenceId) {
        var result = await _sender.Send(new DeleteAbsenceCommand(AbsenceId.Create(absenceId)));
        return result.MapToResult();
    }

    [HttpPost("{absenceId:int}/accept")]
    public async Task<ActionResult> Accept(int absenceId) {
        var result = await _sender.Send(new AcceptAbsenceCommand(AbsenceId.Create(absenceId)));
        return result.MapToResult();
    }

    [HttpPost("{absenceId:int}/reject")]
    public async Task<ActionResult> Reject(int absenceId) {
        var result = await _sender.Send(new RejectAbsenceCommand(AbsenceId.Create(absenceId)));
        return result.MapToResult();
    }
}