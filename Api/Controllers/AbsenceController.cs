using Application.Dtos;
using Application.Features.Absence.AcceptAbsence;
using Application.Features.Absence.CreateAbsence;
using Application.Features.Absence.GetAbsence;
using Application.Features.Absence.GetAbsences;
using Application.Features.Absence.RejectAbsence;
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
    public async Task<ActionResult> GetAll([FromRoute] AbsenceRouteParameters routeParameters) {
        var result = await _sender.Send(new GetAbsencesQuery());
        return result.MapResult();
    }

    [HttpGet("{absenceId:int}")]
    public async Task<ActionResult> Get(int absenceId) {
        var result = await _sender.Send(new GetAbsenceQuery(AbsenceId.Create(absenceId)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAbsenceCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{absenceId:int}")]
    public ActionResult Update(int userId, int absenceId) {
        throw new NotImplementedException();
    }

    [HttpDelete("{absenceId:int}")]
    public ActionResult Delete(int userId, int absenceId) {
        throw new NotImplementedException();
    }

    [HttpPost("{absenceId:int}/accept")]
    public async Task<ActionResult> Accept(int absenceId, [FromBody] AbsenceAcceptRequest request) {
        var result = await _sender.Send(new AcceptAbsenceCommand(AbsenceId.Create(absenceId), request.Description));
        return result.MapResult();
    }

    [HttpPost("{absenceId:int}/reject")]
    public async Task<ActionResult> Reject(int absenceId, [FromBody] AbsenceRejectRequest request) {
        var result = await _sender.Send(new RejectAbsenceCommand(AbsenceId.Create(absenceId), request.Description));
        return result.MapResult();
    }
}